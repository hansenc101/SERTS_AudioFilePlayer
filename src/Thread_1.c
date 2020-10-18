
#include "cmsis_os.h"  // CMSIS RTOS header file
#include "Board_LED.h"
#include "UART_driver.h"
#include "stdint.h"                     // data type definitions
#include "stdio.h"                      // file I/O functions
#include "rl_usb.h"                     // Keil.MDK-Pro::USB:CORE
#include "rl_fs.h"                      // Keil.MDK-Pro::File System:CORE
#include "stm32f4xx_hal.h"
#include "stm32f4_discovery.h"
#include "stm32f4_discovery_audio.h"
#include "math.h"
#include "arm_math.h" // header for DSP library
#include <stdio.h>

// LED constants
#define LED_Green   0
#define LED_Orange  1
#define LED_Red     2
#define LED_Blue    3
#define Show_Files_char "1"

enum commands{
  ListFiles,
  SendComplete,
  SendFiles
};

// State Machine definitions
enum state{
  NoState,
  Idle,
  List,
};


//////////////////////////////////////////////////////////
void Control (void const *argument); // thread function
osThreadId tid_Control; // thread id
osThreadDef (Control, osPriorityNormal, 1, 0); // thread object

// Command queue from Rx_Command to Controller
osMessageQId CMDQueue; // message queue for commands to Thread
osMessageQDef (CMDQueue, 1, uint32_t); // message queue object

// Command queue from State Control to FS
osMessageQId Command_FSQueue; // message queue for commands to Thread
osMessageQDef (Command_FSQueue, 1, uint32_t); // message queue object

// UART receive thread
void Rx_Command (void const *argument);  // thread function
osThreadId tid_RX_Command;  // thread id
osThreadDef (Rx_Command, osPriorityNormal, 1, 0); // thread object

void FS (void const *arg);                           // function prototype for Thread_1
osThreadId tid_FS;  // thread id
osThreadDef (FS, osPriorityNormal, 1, 0);            // define Thread_1

void Init_Thread (void) {
	LED_Initialize(); // Initialize the LEDs
	UART_Init(); // Initialize the UART

	// Create queues
	CMDQueue = osMessageCreate (osMessageQ(CMDQueue), NULL);  // create msg queue
	if (!CMDQueue)return; // Message Queue object not created, handle failure

	Command_FSQueue = osMessageCreate (osMessageQ(Command_FSQueue), NULL);  // create msg queue
	if (!Command_FSQueue)return; // Message Queue object not created, handle failure

	tid_FS = osThreadCreate (osThread(FS), NULL); // create Rx_Command thread
	if (!tid_FS) return;
	tid_RX_Command = osThreadCreate (osThread(Rx_Command), NULL); // create Rx_Command thread
	if (!tid_RX_Command) return;
	tid_Control = osThreadCreate (osThread(Control), NULL);       // create Control thread
	if (!tid_Control) return;

}

// Thread function
void FS(void const *arg){
	osEvent evt; // Receive message object
	//char *file_name = "TestFileName.txt";
	char *StartFileList_msg = "2\n";
	char *EndFileList_msg = "3\n";
	//int len;

	// USB Variables
	usbStatus ustatus; // USB driver status variable
	uint8_t drivenum = 0; // Using U0: drive number
	char *drive_name = "U0:"; // USB drive name
	fsStatus fstatus; // file system status variable
	static FILE *f;

	LED_On(LED_Green);
	ustatus = USBH_Initialize (drivenum); // initialize the USB Host




	while(1)
	{
		evt = osMessageGet (Command_FSQueue, osWaitForever); // receive command
		if (evt.status == osEventMessage && evt.value.v == SendFiles) // check for valid message
		{
			// Process event
			//len = strlen(file_name);
			UART_send(StartFileList_msg,2); // Send start string
			//UART_send(file_name,len);
			//UART_send("\n",1); // this is the VB string terminator "\n"

			if (ustatus == usbOK)
			{
				// loop until the device is OK, may be delay from Initialize
				ustatus = USBH_Device_GetStatus (drivenum); // get the status of the USB device
				while(ustatus != usbOK){
					ustatus = USBH_Device_GetStatus (drivenum); // get the status of the USB device
				}
				// initialize the drive
				fstatus = finit (drive_name);
				if (fstatus != fsOK){
					// handle the error, finit didn't work
				} // end if
				// Mount the drive
				fstatus = fmount (drive_name);
				if (fstatus != fsOK){
					// handle the error, fmount didn't work
				} // end if
				// file system and drive are good to go
				fsFileInfo info;

				info.fileID = 0;                             // info.fileID must be set to 0

				  while (ffind ("U0:*.*", &info) == fsOK)
				  {     // find whatever is in drive "R:"
					  if(info.attrib == ' ')
					  {
						  UART_send(info.name, strlen(info.name));
						  UART_send("\n",1);
					  }
				  }
			} // end if USBH_Initialize

			UART_send(EndFileList_msg,2); // Send end string
		}
	}
}

void Process_Event(uint16_t event){
  static uint16_t   Current_State = NoState; // Current state of the SM
  osEvent evt; // Receive message object
  switch(Current_State){
    case NoState:
      // Next State
      Current_State = Idle;
      // Exit actions
      // Transition actions
      // State1 entry actions
      LED_On(LED_Red);

      break;
    case Idle:
      if(event == ListFiles){
    	  // send command to FS thread to send files
    	  osMessagePut (Command_FSQueue, SendFiles, osWaitForever);

    	  Current_State = List;
    	  // Exit actions
    	  LED_Off(LED_Red);
    	  // Transition actions
    	  // State2 entry actions
    	  LED_On(LED_Blue);
      }
      break;
    case List:
      if(event == SendComplete){
    	  Current_State = Idle;
    	  // Exit actions
    	  LED_Off(LED_Blue);
    	  // Transition actions
    	  // State1 entry actions
    	  LED_On(LED_Red);
      }
      break;
    default:
      break;
  } // end case(Current_State)
} // Process_Event


// Thread function
void Control(void const *arg){
  osEvent evt; // Receive message object
  Process_Event(0); // Initialize the State Machine
   while(1){
	  evt = osMessageGet (CMDQueue, osWaitForever); // receive command
      if (evt.status == osEventMessage) { // check for valid message
      Process_Event(evt.value.v); // Process event
    }
   }
}

void Rx_Command (void const *argument){
   char rx_char[2]={0,0};
   while(1){
      UART_receive(rx_char, 1); // Wait for command from PC GUI
    // Check for the type of character received
      if(!strcmp(rx_char,Show_Files_char)){
         // Show_Files command received
         osMessagePut (CMDQueue, ListFiles, osWaitForever);
      } // end if
   }
} // end Rx_Command



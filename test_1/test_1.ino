#include <OSCMessage.h>
#include <OSCBoards.h>

#ifdef BOARD_HAS_USB_SERIAL
#include <SLIPEncodedUSBSerial.h>
SLIPEncodedUSBSerial SLIPSerial( thisBoardsSerialUSB );
#else
#include <SLIPEncodedSerial.h>
SLIPEncodedSerial SLIPSerial(Serial);
#endif

int trig = 2;
int echo = 3;
long lecture_echo;
long cm;

void setup(){

pinMode(trig, OUTPUT);
digitalWrite(trig, LOW);
pinMode(echo, INPUT);
SLIPSerial.begin(9600);

Serial.println ("Bienvenue sur les tutoriels d'IHM 3D");
}

void loop(){

digitalWrite(trig, HIGH);
delayMicroseconds(10);
digitalWrite(trig, LOW);
lecture_echo = pulseIn(echo,HIGH);
cm = lecture_echo /58;
Serial.print("Distance en cm :");
Serial.println(cm);
delay(500);
}

void sendMessage(char * addr, int value) {
  OSCMessage msg(addr);
  msg.add(value);

  SLIPSerial.beginPacket();
    msg.send(SLIPSerial);
  SLIPSerial.endPacket();
    msg.empty();  
  
  
}
  
  
  

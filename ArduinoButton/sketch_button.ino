int state; //state machine current state
int ledPin = 5; // output pin van led
int input = 1; // input pin op analog
int valueIn; // value van input pins voltage
bool button = false; // bool die de button bij houd
bool onButtonClick = false; // monostable (1 time pulse) boolean

void setup() {
Serial.begin(9600);
pinMode(ledPin,OUTPUT); // zet pin op output mode
}

void loop() {
    valueIn = analogRead(input); //zet value gelijk aan analog input van pin
    if(valueIn >= 1010){
      button = true;
    }else{
      button = false;
    } //als value hoog staat zet de boolean aan zo niet dan niet

    switch (state){
      case 0:{
        if(button){// als je nog niet geklikt hebt en je drukt de knop in dan:
          onButtonClick = true; // doe de 1 time pulse aan;
          state = 1; // transition naar state 1
        }
        break;
      }
      case 1:{// state 1 behaald
        onButtonClick = false; // 1 time tick gaat weer uit zodat hij niet langer dan 1 tick aan is
        if(!button){// als je de knop weer los laat, reset alles
          state = 0;
        }
        break;
      }
    }
    if(onButtonClick){
      digitalWrite(ledPin,HIGH);// stuur een signaal naar de led met de 1 time pulse variabel
      Serial.println(onButtonClick);
    }
     delay(100);
     digitalWrite(ledPin,LOW); // doe hem weer uit na 1/10 van een seconde
}

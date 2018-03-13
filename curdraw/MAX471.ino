const int max471In = A0;

int RawValue= 0;
float Current = 0;

void setup(){  
  pinMode(max471In, INPUT);
  Serial.begin(115200);
}

void loop(){  
  RawValue = analogRead(max471In); 
  Current = (RawValue * 4.87 )/ 1024.0; // scale the ADC  

  static float total = 0.0;
  static int counter = 0;

  total += Current;
  if(counter++ == 100)
  {
    total = total / counter;

    Serial.print(millis());
    Serial.print(",");
    Serial.print(total,3); //3 digits after decimal point
    Serial.println();
  
    counter = 0;
    total = 0.0;
  }  
  
  delay(1);  
}

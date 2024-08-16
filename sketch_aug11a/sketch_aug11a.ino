unsigned long previousMillis = 0; // Son işlem zamanını saklamak için
const long interval = 1000; // 1 saniye (1000 milisaniye)
bool systemOn = false; // Sistemin açık olup olmadığını takip eder

void setup() {
  Serial.begin(9600);
  randomSeed(analogRead(0)); // Rastgele sayı üretmek için başlangıç değeri
}

void loop() {
  if (Serial.available() > 0) {
    String command = Serial.readStringUntil('\n');
    command.trim();

    if (command == "System On") {
      systemOn = true;
    } else if (command == "System Off") {
      systemOn = false;
    }
  }

  if (systemOn) {
    unsigned long currentMillis = millis(); // Şu anki zamanı al

    // Eğer 1 saniye geçtiyse
    if (currentMillis - previousMillis >= interval) {
      previousMillis = currentMillis; // Son işlem zamanını güncelle
      int randomNumber = random(0, 100); // 0 ile 100 arasında rastgele sayı üret
      Serial.println(randomNumber);      // Seri port üzerinden gönder
    }
  }
}

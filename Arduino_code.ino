#include <ESP8266WiFi.h>
#include <FirebaseESP8266.h>
#include <NewPing.h>

#define TRIG_PIN D1  // GPIO5
#define ECHO_PIN D2  // GPIO4
#define MAX_DISTANCE 400  // Maximum measurable distance in cm

// WiFi credentials
#define WIFI_SSID "your-SSID"
#define WIFI_PASSWORD "your-PASSWORD"

// Firebase credentials
#define FIREBASE_HOST "https://ar-water-monitoring-default-rtdb.asia-southeast1.firebasedatabase.app/"
#define FIREBASE_AUTH "AIzaSyAM5qZDfGme7PabSJHIcFrXtyJ4dVGSj-4"

FirebaseData firebaseData;
NewPing sonar(TRIG_PIN, ECHO_PIN, MAX_DISTANCE);

void setup() {
    Serial.begin(115200);
    WiFi.begin(WIFI_SSID, WIFI_PASSWORD);
    Serial.print("Connecting to WiFi");
    while (WiFi.status() != WL_CONNECTED) {
        Serial.print(".");
        delay(1000);
    }
    Serial.println("\nConnected to WiFi");
    
    Firebase.begin(FIREBASE_HOST, FIREBASE_AUTH);
    Firebase.reconnectWiFi(true);
    Serial.println("Firebase initialized");
}

void loop() {
    delay(1000);
    int distance = sonar.ping_cm();

    if (distance == 0) {
        Serial.println("Out of range!");
        Firebase.setInt(firebaseData, "/ultrasonic/distance", -1); // Indicate out of range with -1
    } else {
        Serial.print("Distance: ");
        Serial.print(distance);
        Serial.println(" cm");
        
        if (Firebase.setInt(firebaseData, "/ultrasonic/distance", distance)) {
            Serial.println("Data sent to Firebase successfully");
        } else {
            Serial.print("Failed to send data: ");
            Serial.println(firebaseData.errorReason());
        }
    }
}
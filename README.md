
# 🎮 TinyML-Based Motion-Controlled Endless Runner

An end-to-end embedded AI project that enables real-time motion-controlled gameplay by integrating an **ESP32**, **MPU6050 motion sensor**, **TinyML**, and **Unity**. Hand gestures are classified on-device using a machine learning model and transmitted to Unity through UART serial communication for low-latency player control.

---

## 📌 Overview

This project demonstrates the complete TinyML workflow:

- Motion data acquisition using MPU6050
- Data preprocessing and model training in Google Colab
- TinyML model development using Edge Impulse
- Deployment on ESP32
- Real-time serial communication with Unity
- Motion-controlled endless runner gameplay

The player performs physical hand gestures to trigger **Jump** and **Slide** actions in the game.

---

## 🚀 Features

- 🎮 Motion-controlled endless runner game
- 🤖 TinyML gesture recognition
- 📡 ESP32–Unity serial communication (UART)
- ⚡ Real-time edge inference
- 🏃 Jump and Slide gesture detection
- ☁️ No cloud connectivity required

---

## 🛠 Hardware

- ESP32 Development Board
- MPU6050 Accelerometer & Gyroscope
- USB Cable

---

## 💻 Software & Tools

- Unity
- Arduino IDE
- Google Colab
- Python
- Scikit-learn
- Edge Impulse
- C#

---

## 🧠 Machine Learning Pipeline

1. Collected motion data from the MPU6050 sensor.
2. Preprocessed the dataset using Python.
3. Created sliding windows for feature extraction.
4. Trained a **Random Forest Classifier** in Google Colab.
5. Evaluated the model using classification metrics.
6. Built and optimized a TinyML model in Edge Impulse.
7. Deployed the TinyML model to the ESP32.
8. Sent predicted gestures to Unity via UART.
9. Controlled the game character in real time.

---

## 📊 Model Performance

### Google Colab Model

| Metric | Value |
|---------|--------|
| Algorithm | Random Forest |
| Dataset | 4,033 motion samples |
| Features | 12 |
| Training Accuracy | 100% |
| Test Accuracy | **98.75%** |
| Precision | **0.99** |
| Recall | **0.99** |
| F1 Score | **0.99** |

---

## 📂 Project Structure

```
ESP32-Motion-Controlled-Endless-Runner
│
├── Arduino_Code/
│
├── Unity_Game/
│
├── TinyML/
│   ├── Google_Colab.ipynb
│   ├── EdgeImpulse_Model
│   └── Model_Metrics
│
├── Dataset/
│
├── Images/
│
├── Demo/
│
└── README.md
```

---

## 🎮 Gameplay Workflow

```
MPU6050 Motion
        │
        ▼
     ESP32
        │
        ▼
TinyML Gesture Classification
        │
        ▼
 UART Serial Communication
        │
        ▼
 Unity Endless Runner
        │
        ▼
 Jump / Slide
```

---

## 📷 Project Images

### Hardware Setup

(Add hardware image)

### Unity Gameplay

(Add gameplay screenshot)

### Edge Impulse Model

(Add Edge Impulse screenshot)

### Confusion Matrix

(Add confusion matrix)

---

## 🎥 Demo

A demonstration video of the project is available below.

(Add YouTube link or GitHub video)

---

## 📈 Future Improvements

- Add additional gesture classes
- Bluetooth/Wi-Fi communication
- CNN/LSTM-based gesture recognition
- Mobile game support
- Multiplayer functionality

---

## 👩‍💻 Author

**Shrawani [Last Name]**

Electronics & Telecommunication Engineering Student

- LinkedIn: *(Add link)*
- GitHub: *(Add link)*

---

## ⭐ If you found this project interesting, consider giving it a star!

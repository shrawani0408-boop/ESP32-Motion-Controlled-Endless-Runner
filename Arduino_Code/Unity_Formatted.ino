#include <Wire.h>
#include <cstring>
#include <Motion_Classification_pt4_inferencing.h>

#define MPU6050_ADDR 0x68

float features[EI_CLASSIFIER_DSP_INPUT_FRAME_SIZE];

int raw_feature_get_data(size_t offset, size_t length, float *out_ptr)
{
    memcpy(out_ptr, features + offset, length * sizeof(float));
    return 0;
}

void setup()
{
    Serial.begin(38400);
    delay(2000);

    Serial.println("STARTED");

    Wire.begin(21, 22);

    // Wake MPU6050
    Wire.beginTransmission(MPU6050_ADDR);
    Wire.write(0x6B);
    Wire.write(0);
    Wire.endTransmission(true);

    Serial.println("MPU6050 + Edge Impulse Ready");
}

void loop()
{
    int idx = 0;

    // Collect samples
    for (int s = 0; s < EI_CLASSIFIER_RAW_SAMPLE_COUNT; s++)
    {
        Wire.beginTransmission(MPU6050_ADDR);
        Wire.write(0x3B);
        Wire.endTransmission(false);

        Wire.requestFrom(MPU6050_ADDR, 14, true);

        int16_t ax = Wire.read() << 8 | Wire.read();
        int16_t ay = Wire.read() << 8 | Wire.read();
        int16_t az = Wire.read() << 8 | Wire.read();

        Wire.read();
        Wire.read();

        int16_t gx = Wire.read() << 8 | Wire.read();
        int16_t gy = Wire.read() << 8 | Wire.read();
        int16_t gz = Wire.read() << 8 | Wire.read();

        features[idx++] = (float)ax;
        features[idx++] = (float)ay;
        features[idx++] = (float)az;

        features[idx++] = (float)gx;
        features[idx++] = (float)gy;
        features[idx++] = (float)gz;

        delay(EI_CLASSIFIER_INTERVAL_MS);
    }

    signal_t signal;
    signal.total_length = EI_CLASSIFIER_DSP_INPUT_FRAME_SIZE;
    signal.get_data = &raw_feature_get_data;

    ei_impulse_result_t result = {0};

    EI_IMPULSE_ERROR res = run_classifier(&signal, &result, false);

    if (res != EI_IMPULSE_OK)
    {
        Serial.print("Classifier error: ");
        Serial.println(res);
        return;
    }

    float tiltScore  = result.classification[0].value;
    float shakeScore = result.classification[1].value;
    float idleScore  = result.classification[2].value;

    // Tilt = JUMP
    if (tiltScore > 0.80)
    {
        Serial.println("JUMP");
    }

    // Shake = SLIDE
    if (shakeScore > 0.80)
    {
        Serial.println("SLIDE");
    }
}
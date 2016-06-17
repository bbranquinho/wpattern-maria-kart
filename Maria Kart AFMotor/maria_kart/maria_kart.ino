#include <AFMotor.h>

AF_DCMotor motor_left(1);
AF_DCMotor motor_right(4);

// Variables
uint8_t speedLeft = 0;
uint8_t speedRight = 0;
uint8_t currentDirection = FORWARD;

void setup()
{
  // Set the direction of each motor.
  setDirection(currentDirection);

  // Configure the BT Serial1 communication.
  Serial1.begin(9600);
}

void loop()
{
  readInput();
  executeSpeed();

  Serial1.print("Speed Left: ");
  Serial1.println(speedRight);
  Serial1.print("Speed Right: ");
  Serial1.println(speedRight);

  delay(15);
}

String messageRead = "";

void readInput() {
  char character;
  uint8_t count = 1;

  while (Serial1.available() > 0) {
    character = Serial1.read();

    if (character == ':') {
      switch (messageRead[0])
      {
        case 'B':
        case 'b':
          speedLeft = atoi(messageRead.substring(1, 4).c_str());
          speedRight = atoi(messageRead.substring(4, 7).c_str());
          break;

        case 'H':
        case 'h':
          speedLeft = speedRight = 0;
          break;

        case 'D':
        case 'd':
          changeDirection();
          break;
      }
      messageRead = "";
    } else {
      messageRead += character;
    }
  }
}

void changeDirection() {
  if (currentDirection == FORWARD) {
    currentDirection = BACKWARD;
  } else {
    currentDirection = FORWARD;
  }

  setDirection(currentDirection);
}


void executeSpeed() {
  motor_left.setSpeed(speedLeft);
  motor_right.setSpeed(speedRight);
}

void setDirection(uint8_t motorDirection) {
  motor_left.run(motorDirection);
  motor_right.run(motorDirection);
}


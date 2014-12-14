enum DIRECTION { FOWARD, BACKWARD };

// Digital
const uint8_t ENA = 5;
const uint8_t IN1 = 2;
const uint8_t IN2 = 3;
const uint8_t ENB = 6;
const uint8_t IN3 = 4;
const uint8_t IN4 = 7;

// Variables
uint8_t speedA = 0;
uint8_t speedB = 0;
DIRECTION currentDirection = FOWARD;

void setup()
{
	// Setup motors.
	pinMode(ENA, OUTPUT);
	pinMode(ENB, OUTPUT);
	pinMode(IN1, OUTPUT);
	pinMode(IN2, OUTPUT);
	pinMode(IN3, OUTPUT);
	pinMode(IN4, OUTPUT);

	// Stop driving.
	digitalWrite(ENA, LOW);
	digitalWrite(ENB, LOW);

	// Set the direction of each motor.
	setMotorDirection();

	// Configure the BT Serial1 communication.
	Serial1.begin(9600);
}

void loop()
{
	readInput();
	analogWrite(ENA, speedA);
	analogWrite(ENB, speedB);
	delay(15);
	Serial1.print("Speed A: ");
	Serial1.println(speedA);
	Serial1.print("Speed B: ");
	Serial1.println(speedB);
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
					speedA = atoi(messageRead.substring(1, 4).c_str());
					speedB = atoi(messageRead.substring(4, 7).c_str());
					break;

				case 'H':
				case 'h':
					speedA = speedB = 0;
					break;

				case 'D':
				case 'd':
					setMotorDirection();
					break;
			}
			messageRead = "";
		} else {
			messageRead += character;
		}
	}
}

void setMotorDirection() {
	if (currentDirection == FOWARD) {
		digitalWrite(IN2, LOW);
		digitalWrite(IN3, LOW);
		digitalWrite(IN1, HIGH); // setting motorA's directon
		digitalWrite(IN4, HIGH); // setting motorB's directon
		currentDirection = BACKWARD;
	} else {
		digitalWrite(IN1, LOW);
		digitalWrite(IN4, LOW);
		digitalWrite(IN2, HIGH); // setting motorB's directon
		digitalWrite(IN3, HIGH); // setting motorA's directon
		currentDirection = FOWARD;
	}
}

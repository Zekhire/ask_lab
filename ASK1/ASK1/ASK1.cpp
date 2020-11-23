#include "pch.h"
#include <iostream>
#include <string>
#include <fstream>
#include <windows.h>
#include <math.h>
#include <vector>

using namespace std;


struct regist
{
	unsigned char H = 0, L = 0;
	bool overflow = false;
};

regist reg[4];

bool dictionary(string input, int type, string arg1 = "none") {
	string orders[] = { "MOV", "ADD", "SUB" };														// <- obsługiwane nazwy rejestrów
	string args[] = { "AX", "AL", "AH", "BX", "BL", "BH", "CX", "CL", "CH", "DX", "DL", "DH" };		// <- obsługiwane nazwy rejestrów
	//string args[] = { "AL", "AH", "BL", "BH", "CL", "CH", "DL", "DH" };								// <- obsługiwane nazwy rejestrów
	switch (type) {
	case 1: {
		for (int i = 0; i < 3; i++) {
			if (input == orders[i]) {
				return true;
			}
		}
		return false;
	}
	case 2: {
		for (int i = 0; i < 12; i++) {								// <- sprawdzenie czy słownik zawiera podany argument
			if (input == args[i]) {
				return true;
			}
		}
		return false;
	}
	case 3: {
		for (int i = 0; i < 12; i++) {								// <- sprawdzenie czy słownik zawiera podany argument
			if (input == args[i]) {
				return true;
			}
		}
		if (input.length() == 1) {
			if (((int)input[0] >= 48) && ((int)input[0] <= 57)) {	// <- argument będący pojedynczą cyfrą musi być w przedziale od 0 do 9
				return true;
			}
		}
		if ((input.length() <= 5)) {					// <- rejestry są w najlepszym przypadku 16 bitowe, czyli długość liczby wynosi maksymalnie 3 
			if ((int)input[0] == 48) {
				return false;
			}
			int value = 0;
			int power = 0;
			for (int i = input.length() - 1; i >= 0; i--) {
				if (((int)input[i] < 48) || ((int)input[i] > 57)) {			// <- sprawdzenie czy jako argument podano ciąg w którym nie występują litery
					return false;
				}
				else {
					value += ((int)input[i] - 48) * pow(10, power);			// <- wyznaczanie podanej wartości
				}
				power++;
			}
			if (arg1[1] == 'X') {										// <- jako pierwszy argument podano cały rejestr
				if ((value > (256 * 256) - 1) || (value < 0)) {				// <- sprawdzenie czy podana wartość mieści się w zakresie (16 bitów bez znaku)
					return false;
				}
			}
			else {
				if ((value > 255) || (value < 0)) {						// <- sprawdzenie czy podana wartość mieści się w zakresie (8 bitów bez znaku)
					return false;
				}
			}
			return true;												// <- podano poprawną wartość
		}
		else
			return false;
	}
	}
	return false;															// <- domyślnie odrzucaj
}

void Displayer(string statement, HANDLE color, WORD col) {
	SetConsoleTextAttribute(color, col);
	cout << statement;
	SetConsoleTextAttribute(color, FOREGROUND_GREEN | FOREGROUND_BLUE | FOREGROUND_RED);
}

void orderDisplayer(string statement, HANDLE color, WORD col, string order = "none", string arg1 = "none", string arg2 = "none") {
	int epoch = 0;
	if (order != "none") {
		epoch++;
	}
	if (arg1 != "none") {
		epoch++;
	}
	if (arg2 != "none") {
		epoch++;
	}
	Displayer(statement, color, col);
	if (epoch > 0) {
		for (int i = 0; i < epoch; i++) {
			switch (i) {
			case 0: {
				Displayer(order + " ", color, FOREGROUND_BLUE | FOREGROUND_RED | FOREGROUND_INTENSITY);
				break;
			}
			case 1: {
				Displayer(arg1, color, FOREGROUND_BLUE | FOREGROUND_INTENSITY);
				break;
			}
			case 2: {
				Displayer(", ", color, FOREGROUND_GREEN | FOREGROUND_BLUE | FOREGROUND_RED | FOREGROUND_INTENSITY);
				if ((int)arg2[0] > 57)
					Displayer(arg2, color, FOREGROUND_BLUE | FOREGROUND_INTENSITY);
				else
					Displayer(arg2, color, FOREGROUND_GREEN | FOREGROUND_INTENSITY);
				break;
			}
			}
		}
		cout << endl;
	}
	SetConsoleTextAttribute(color, FOREGROUND_GREEN | FOREGROUND_BLUE | FOREGROUND_RED);


}

void show(vector<string> orders, vector<string> args1, vector<string> args2, HANDLE color) {
	//cout << endl;
	for (int i = 0; i < orders.size(); i++) {
		orderDisplayer(to_string(i + 1) + ".~	", color, FOREGROUND_BLUE, orders[i], args1[i], args2[i]);
	}
	//cout << endl;
}

void save(string title, vector<string> orders, vector<string> args1, vector<string> args2, HANDLE color) {
	fstream file;
	file.open(title + ".txt", ios::out);
	for (int i = 0; i < orders.size(); i++)
		file << orders[i] << " " << args1[i] << ", " << args2[i] << endl;
	Displayer("Pomyślnie zapisano wszystkie rozkazy\n", color, FOREGROUND_GREEN | FOREGROUND_BLUE);
	file.close();
}

void load(string title, vector<string> &orders, vector<string> &args1, vector<string> &args2, HANDLE color) {
	fstream file;
	file.open(title + ".txt", ios::in);
	string line;
	orders.clear();
	args1.clear();
	args2.clear();
	while (getline(file, line)) {
		orders.push_back(line.substr(0, 3));
		for (int i = 5; i < line.length(); i++) {
			if ((int)line[i] == 44) {
				args1.push_back(line.substr(4, i - 4));
				args2.push_back(line.substr(i + 2, line.length() - (i + 2)));
				break;
			}
		}
	}
	Displayer("Pomyślnie wczytano wszystkie rozkazy\n", color, FOREGROUND_GREEN | FOREGROUND_BLUE);
	file.close();
}

void strTOint(bool &correct, string input, int &value, vector<string> &orders, HANDLE color) {
	int power = 0;
	for (int i = input.length() - 1; i >= 0; i--) {
		if (((int)input[i] < 48) || ((int)input[i] > 57)) {			// <- sprawdzenie czy jako argument podano ciąg w którym nie występują litery
			Displayer("Podano złą wartość\n", color, FOREGROUND_RED | FOREGROUND_INTENSITY);
			correct = false;
			break;
		}
		else {
			value += ((int)input[i] - 48) * pow(10, power);			// <- wyznaczanie podanej wartości
			if (value > orders.size()) {
				Displayer("Podano złą wartość\n", color, FOREGROUND_RED | FOREGROUND_INTENSITY);
				correct = false;
				break;
			}
		}
		power++;
	}
}

void reset(HANDLE color) {
	for (int i = 0; i < 4; i++) {
		reg[i].H = 0;
		reg[i].L = 0;
		reg[i].overflow = false;
	}
	Displayer("Pomyślnie wyczyszczono rejestry\n", color, FOREGROUND_GREEN | FOREGROUND_BLUE);
}

void append(vector<string> &orders, vector<string> &args1, vector<string> &args2, HANDLE color, int index = -1) {
	string order;
	string arg1;
	string arg2;
	bool ord_breaker = true;
	Displayer("WPISYWANIE ROZKAZÓW\n", color, FOREGROUND_GREEN | FOREGROUND_BLUE | FOREGROUND_INTENSITY);
	while (ord_breaker) {
		Displayer("Podaj rozkaz\n", color, FOREGROUND_GREEN | FOREGROUND_BLUE);
		Displayer("$  ", color, FOREGROUND_GREEN | FOREGROUND_RED | FOREGROUND_INTENSITY);
		cin >> order;
		if (order == "<-") {												// <- cofnij
			break;
		}
		if (!dictionary(order, 1)) {
			Displayer("Podano złą wartość\n", color, FOREGROUND_RED | FOREGROUND_INTENSITY);
			continue;
		}
		else {
			bool arg1_breaker = true;
			while (arg1_breaker) {												// <- Wpisanie pierwszego argumentu
				orderDisplayer("Podaj pierwszy argument\n", color, FOREGROUND_GREEN | FOREGROUND_BLUE, order);
				Displayer("$  ", color, FOREGROUND_GREEN | FOREGROUND_RED | FOREGROUND_INTENSITY);
				cin >> arg1;
				if (arg1 == "<-") {												// <- cofnij
					break;
				}
				if (!dictionary(arg1, 2)) {
					Displayer("Podano złą wartość\n", color, FOREGROUND_RED | FOREGROUND_INTENSITY);
					continue;
				}
				else {
					bool arg2_breaker = true;
					while (arg2_breaker) {												// <- Wpisanie drugiego argumentu
						orderDisplayer("Podaj drugi argument\n", color, FOREGROUND_GREEN | FOREGROUND_BLUE, order, arg1);
						Displayer("$  ", color, FOREGROUND_GREEN | FOREGROUND_RED | FOREGROUND_INTENSITY);
						cin >> arg2;
						if (arg2 == "<-") {												// <- cofnij
							break;
						}
						if (!dictionary(arg2, 3, arg1)) {
							Displayer("Wpisano zły argument!\n", color, FOREGROUND_RED | FOREGROUND_INTENSITY);
							continue;
						}
						else {
							if (index == -1) {
								orders.push_back(order);
								args1.push_back(arg1);
								args2.push_back(arg2);
							}
							else {
								orders.insert(orders.begin() + index - 1, order);
								args1.insert(args1.begin() + index - 1, arg1);
								args2.insert(args2.begin() + index - 1, arg2);
								index++;
							}
							orderDisplayer("Wpisano następujący rozkaz:\n", color, FOREGROUND_GREEN | FOREGROUND_BLUE, order, arg1, arg2);
							arg1_breaker = false;
							arg2_breaker = false;
							break;
						}
					}
				}
			}
		}
	}
}

void del(vector<string> &orders, vector<string> &args1, vector<string> &args2, HANDLE color) {
	string input;
	int value = 0;
	while (true) {
		value = 0;
		bool correct = true;
		Displayer("Podaj numer linii, którą chcesz usunąć\n", color, FOREGROUND_GREEN | FOREGROUND_BLUE);
		Displayer("$  ", color, FOREGROUND_GREEN | FOREGROUND_RED | FOREGROUND_INTENSITY);
		cin >> input;
		if (input == "<-") {
			break;
		}
		else if (input == "all") {
			orders.clear();
			args1.clear();
			args2.clear();
			break;
		}
		strTOint(correct, input, value, orders, color);
		if (correct) {
			orders.erase(orders.begin() + value - 1);
			args1.erase(args1.begin() + value - 1);
			args2.erase(args2.begin() + value - 1);
			break;
		}
	}
}

void insert(vector<string> &orders, vector<string> &args1, vector<string> &args2, HANDLE color) {
	string input;
	int value;
	int power;
	while (true) {
		value = 0;
		power = 0;
		bool correct = true;
		Displayer("Podaj numer linii, w której chcesz wstawić rozkaz\n", color, FOREGROUND_GREEN | FOREGROUND_BLUE);
		Displayer("$  ", color, FOREGROUND_GREEN | FOREGROUND_RED | FOREGROUND_INTENSITY);
		cin >> input;
		if (input == "<-") {
			break;
		}
		strTOint(correct, input, value, orders, color);
		if (correct) {
			append(orders, args1, args2, color, value);
			break;
		}
	}
}

string changetitle(string *title, HANDLE color) {
	string newtitle;
	while (true) {
		bool good = true;
		Displayer("WPISYWANIE NAZWY PLIKU\n", color, FOREGROUND_GREEN | FOREGROUND_BLUE | FOREGROUND_INTENSITY);
		Displayer("$  ", color, FOREGROUND_GREEN | FOREGROUND_RED | FOREGROUND_INTENSITY);
		cin >> newtitle;
		if (newtitle == "<-") {
			return *title;
		}
		else {
			for (int i = 0; i < (newtitle).length(); i++) {
				if (((int)newtitle[i] < 48) || (((int)newtitle[i] > 57) && ((int)newtitle[i] < 65)) || (((int)newtitle[i] > 91) && ((int)newtitle[i] < 97)) || ((int)newtitle[i] > 122)) {
					good = false;
					break;
				}
			}
			if (!good) {
				Displayer("Podano nieprawidłową nazwę pliku\n", color, FOREGROUND_RED | FOREGROUND_INTENSITY);
			}
			else {
				return newtitle;
			}
		}
	}
}

void execute(vector <string> coms, vector <string> args1, vector <string> args2, HANDLE color)
{
	bool step;
	string input;
	while (true) {
		bool good = true;
		Displayer("Podaj tryb\n", color, FOREGROUND_GREEN | FOREGROUND_BLUE);
		Displayer("$  ", color, FOREGROUND_GREEN | FOREGROUND_RED | FOREGROUND_INTENSITY);
		cin >> input;
		if (input == "<-") {
			break;
		}
		else if (input == "debug") {
			step = true;
		}
		else if (input == "run") {
			step = false;
		}
		else {
			Displayer("Podano nieprawidłowy tryb\n", color, FOREGROUND_RED | FOREGROUND_INTENSITY);
			continue;
		}
		int arg_int;
		unsigned char* HL[2] = { nullptr, nullptr };
		unsigned com = 0;

		string command;		//komenda
		string arg1;		//argument 1
		string arg2;		//argument 2

		bool reg_addr = false;
		bool _8bit = false;

		regist *operand_ptr[2];
		operand_ptr[0] = nullptr;
		operand_ptr[1] = nullptr;
		int n = 0;

		while (n < coms.size())
		{

			reg_addr = false;
			_8bit = false;

			command = coms[n];
			arg1 = args1[n];
			arg2 = args2[n];
			if (step)
				orderDisplayer(to_string(n + 1) + ".~	", color, FOREGROUND_BLUE, command, arg1, arg2);
			n++;
			operand_ptr[0] = nullptr;
			operand_ptr[1] = nullptr;
			HL[0] = nullptr;
			HL[1] = nullptr;
			if (command == "MOV")com = 1;
			else if (command == "ADD")com = 2;
			else if (command == "SUB")com = 3;
			else com = 0;

			//translacja komendy na adres (pierwszy argument)
			//wybór rejestru, na którym przeprowadzona zostanie zadana operacja
			if (arg1[0] == 'A')
			{
				operand_ptr[0] = &reg[0];
			}
			else if (arg1[0] == 'B')
			{
				operand_ptr[0] = &reg[1];
			}
			else if (arg1[0] == 'C')
			{
				operand_ptr[0] = &reg[2];
			}
			else if (arg1[0] == 'D')
			{
				operand_ptr[0] = &reg[3];
			}

			//sprawdzenie, czy operacja odnosi się do starszej, młodszej, czy obu części rejestru
			if (arg1[1] == 'H')
			{
				_8bit = true;
				HL[0] = &operand_ptr[0]->H;
			}
			else if (arg1[1] == 'L')
			{
				_8bit = true;
				HL[0] = &operand_ptr[0]->L;
			}
			else if (arg1[1] == 'X')
			{
				_8bit = false;
				HL[0] = &operand_ptr[0]->L;
			}
			else HL[0] = nullptr;

			//translacja komendy na adres (drugi argument)	
				//wybór rejestru, na którym przeprowadzona zostanie zadana operacja
			if (arg2[0] == 'A')
			{
				operand_ptr[1] = &reg[0];
				reg_addr = true;
			}
			else if (arg2[0] == 'B')
			{
				operand_ptr[1] = &reg[1];
				reg_addr = true;
			}
			else if (arg2[0] == 'C')
			{
				operand_ptr[1] = &reg[2];
				reg_addr = true;
			}
			else if (arg2[0] == 'D')
			{
				operand_ptr[1] = &reg[3];
				reg_addr = true;
			}

			//sprawdzenie, czy operacja odnosi się do starszej, młodszej, czy obu części rejestru
			if (arg2[1] == 'H')
			{
				HL[1] = &operand_ptr[1]->H;
				_8bit = true;
			}
			else if (arg2[1] == 'L')
			{
				HL[1] = &operand_ptr[1]->L;
				_8bit = true;
			}
			else if (arg2[1] == 'X')
			{
				_8bit = false;
			}
			else HL[1] = nullptr;

			//jeśli flaga reg_addr2 nie została ustawiona, oznacza to, że drugi argument jest liczbą.
			if (!reg_addr)
			{
				arg_int = stoi(arg2);
				//wartość mniejsza, niż 256 oznacza, że można ją umieścić w tylko jednym rejestrze
				if (arg_int < 256)
				{
					_8bit = true;
					unsigned char temp;
					temp = arg_int;
					HL[1] = (unsigned char*)&arg_int;
				}
				//wartość większa niż 256 oznacza, że należy wartość przenieść do oddzielnego rejestru
				else if (arg_int < 256 * 256)
				{
					_8bit = false;
					regist temp;
					temp.L = arg_int % 256;
					temp.H = arg_int >> 8;
					operand_ptr[1] = &temp;
				}
			}

			switch (com)
			{
			case 1:
				//obsługa instrukcji MOV

				if (!_8bit)*operand_ptr[0] = *operand_ptr[1];
				else *HL[0] = *HL[1];

				break;
			case 3:
				//obsługa instrukcji SUB
				//odwrócenie "znaku"
				if (!_8bit)
				{
					operand_ptr[1]->H = operand_ptr[1]->H * -1;
					operand_ptr[1]->L = operand_ptr[1]->L * -1;
				}
				else *HL[1] *= -1;
			case 2:
				//obsługa instrukcji ADD
			{
				if (_8bit)
				{
					int buff = *HL[0];
					buff += *HL[1];

					operand_ptr[0]->overflow = (buff > 256);

					*HL[0] = buff;

					operand_ptr[0]->H += operand_ptr[0]->overflow;
					operand_ptr[0]->overflow = false;
					break;
				}
				int buff = operand_ptr[0]->L;
				buff += operand_ptr[1]->L;
				//if (_8bit)*HL[0] += *HL[1];

				if (buff > 256)
				{
					operand_ptr[0]->L = buff % 256;
					operand_ptr[0]->overflow = true;
				}
				else operand_ptr[0]->L = buff;
				operand_ptr[0]->H += operand_ptr[1]->H;

				if (com == 3)
				{
					//odwrócenie znaku, aby znów przywrócić pozytywne wartośći
					operand_ptr[1]->H = operand_ptr[1]->H * -1;
					operand_ptr[1]->L = operand_ptr[1]->L * -1;
				}
			}
			break;
			default:
				cout << "\n\nNie rozpoznano komendy";
			}


			if ((n == coms.size()) || (step)) {
				Displayer("REJ	X	H	L\n", color, FOREGROUND_GREEN | FOREGROUND_RED);
				for (int i = 0; i < 4; i++)
				{
					unsigned X = reg[i].L + (reg[i].H << 8);
					string str = "";
					str += (char)(65 + i);
					Displayer(str, color, FOREGROUND_GREEN);
					Displayer(":	", color, FOREGROUND_GREEN | FOREGROUND_BLUE | FOREGROUND_RED | FOREGROUND_INTENSITY);
					cout << X << "	" << (int)reg[i].H << "	" << (int)reg[i].L << "\n";
				}

				if (step) {
					cout << "\n\n";
					system("pause>nul");
				}
			}
		}
		break;
	}
}

void console(HANDLE color) {
	vector<string> orders;
	vector<string> args1;
	vector<string> args2;
	string title = "default";
	string input;
	system("cls");
	while (true) {
		Displayer("KONSOLA\n", color, FOREGROUND_GREEN | FOREGROUND_BLUE | FOREGROUND_INTENSITY);
		Displayer("$  ", color, FOREGROUND_GREEN | FOREGROUND_RED | FOREGROUND_INTENSITY);
		cin >> input;
		if (input == "show") { show(orders, args1, args2, color); }
		else if (input == "save") { save(title, orders, args1, args2, color); }
		else if (input == "load") { load(title, orders, args1, args2, color); }
		else if (input == "clear") { system("cls"); }
		else if (input == "reset") { reset(color); }
		else if (input == "delete") { show(orders, args1, args2, color); del(orders, args1, args2, color); }
		else if (input == "insert") { show(orders, args1, args2, color); insert(orders, args1, args2, color); }
		else if (input == "append") { append(orders, args1, args2, color); }
		else if (input == "exit") { exit(0); }
		else if (input == "file") { title = changetitle(&title, color); }
		else if (input == "execute") { execute(orders, args1, args2, color); }
		else { Displayer("Wpisano nieprawidłową komendę\n", color, FOREGROUND_RED | FOREGROUND_INTENSITY); }
	}
}


int main() {

	HANDLE color;
	color = GetStdHandle(STD_OUTPUT_HANDLE);
	SetConsoleTextAttribute(color, FOREGROUND_GREEN | FOREGROUND_BLUE | FOREGROUND_RED);
	console(color);
}
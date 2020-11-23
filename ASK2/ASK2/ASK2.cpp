#include "pch.h"
#include <iostream>
#include <string>
#include <fstream>
#include <windows.h>
#include <math.h>
#include <vector>
#include <stdio.h>
#include <time.h>
#pragma comment(lib, "user32.lib")

using namespace std;


struct regist
{
	unsigned char H = 0, L = 0;
	bool overflow = false;
};
const int M = 256;						// <- Arbitralnie przyjęta pojemność stosu
unsigned short stack[M];				// <- STOS
unsigned short SP = M - 1;				// <- Wskaźnik stosu
regist reg[4];

bool dictionary(string input, int type, int &param, string order = "none", string arg1 = "none") {
	string orders[] = { "MOV", "ADD", "SUB" };															// <- obsługiwane nazwy rejestrów
	string args[] = { "AX", "AL", "AH", "BX", "BL", "BH", "CX", "CL", "CH", "DX", "DL", "DH" };			// <- obsługiwane nazwy rejestrów
	switch (type) {
	case 1: {
		for (int i = 0; i < 3; i++) {
			if (input == orders[i]) {
				param = 1;
				return true;
			}
		}
		if (input == "INT") {
			param = 2;
			return true;
		}
		else if (input == "POP") {
			param = 3;
			return true;
		}
		else if (input == "PUSH") {
			param = 3;
			return true;
		}
		else {
			return false;
		}
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
				if ((arg1[1] == 'X') && (input[1] != 'X')) {
					return false;
				}
				else if ((arg1[1] != 'X') && (input[1] == 'X')) {
					return false;
				}
				else {
					return true;
				}
			}
		}
		int length = input.length();
		if ((length <= 5)) {					// <- rejestry są w najlepszym przypadku 16 bitowe, czyli długość liczby wynosi maksymalnie 3 
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
		else {
			return false;
		}
	}
	case 4: {
		for (int i = 0; i < 4; i++) {								// <- sprawdzenie czy słownik zawiera podany argument
			if (input == args[i * 3]) {
				return true;
			}
		}
		return false;
	}
	case 5: {
		if (input.length() == 1) {
			if (((int)input[0] >= 48) && ((int)input[0] <= 57)) {
				return true;
			}
		}
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
				if (order.substr(0, 3) == "INT") {
					Displayer(order.substr(0, 3), color, FOREGROUND_BLUE | FOREGROUND_RED | FOREGROUND_INTENSITY);
					Displayer(order.substr(3, order.length() - 3), color, FOREGROUND_GREEN);
				}
				else {
					Displayer(order + " ", color, FOREGROUND_BLUE | FOREGROUND_RED | FOREGROUND_INTENSITY);
				}
				break;
			}
			case 1: {
				if (order.substr(0, 3) == "INT") {
					Displayer(arg1, color, FOREGROUND_GREEN | FOREGROUND_INTENSITY);
				}
				else {
					Displayer(arg1, color, FOREGROUND_BLUE | FOREGROUND_INTENSITY);
				}
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

void help(string arg, HANDLE color) {
	SetConsoleTextAttribute(color, FOREGROUND_GREEN | FOREGROUND_BLUE | FOREGROUND_INTENSITY);
	if (arg == "show") {
		cout << endl << "show" << endl << endl;
		cout << "Komenda służąca do wyświetlania pisanego programu" << endl;
		cout << endl;
	}
	else if (arg == "save") {
		cout << endl << "save" << endl << endl;
		cout << "Komenda służąca do zapisywania zawartości pisanego programu do pliku wybranego wcześniej za pomocą komendy 'file'." << endl;
		cout << "Domyślnie program jest zapisywany w pliku 'default.txt'." << endl;
		cout << endl;
	}
	else if (arg == "load") {
		cout << endl << "load" << endl << endl;
		cout << "Komenda służąca do wczytywania zawartości pliku wybranego wcześniej za pomocą komendy 'file'." << endl;
		cout << "Domyślnie program jest wczytywany z pliku 'default.txt'." << endl;
		cout << endl;
	}
	else if (arg == "reset") {
		cout << endl << "reset" << endl << endl;
		cout << "Komenda służąca do czyszczenia zawartości wszystkich rejestrów." << endl;
		cout << endl;
	}
	else if (arg == "append") {
		cout << endl << "append" << endl << endl;
		cout << "Komenda służąca do dopisania (na koniec programu) nowej linii kodu." << endl;
		cout << endl;
	}
	else if (arg == "delete") {
		cout << endl << "delete" << endl << endl;
		cout << "Komenda służąca do usunięcia wskazanej linii kodu programu." << endl;
		cout << "Podanie liczby wskazuje konkretną linię kodu." << endl;
		cout << "Podanie 'all' kasuje cały kod." << endl;
		cout << endl;
	}
	else if (arg == "insert") {
		cout << endl << "insert" << endl << endl;
		cout << "Komenda służąca do wstawiania nowej linii kodu w wskazanej linii." << endl;
		cout << endl;
	}
	else if (arg == "execute") {
		cout << endl << "execute" << endl << endl;
		cout << "Komenda służąca do realizacji napisanego programu." << endl;
		cout << "Składnia wygląda w sposób następujący:" << endl << endl;
		cout << "execute ARG" << endl << endl;
		cout << "gdzie:" << endl;
		cout << " - ARG1 określa tryb realizacji programu i musi być równe:" << endl;
		cout << "	- 'run' - tryb całościowego wykonania" << endl;
		cout << "	- 'debug' - tryb pracy krokowej" << endl;
		cout << endl;
	}
	else if (arg == "MOV") {
		cout << endl << "MOV" << endl << endl;
		cout << "Instrukcja służąca do przypisywania rejestrowi wartość." << endl;
		cout << "Składnia wygląda w sposób następujący:" << endl << endl;
		cout << "MOV ARG1, ARG2" << endl << endl;
		cout << "gdzie:" << endl;
		cout << " - ARG1 określa rejestr, do którego chcemy wstawić wartość" << endl;
		cout << " - ARG2 określa rejestr, z którego chcemy wstawić wartość lub wartość dziesiętną" << endl;
		cout << "Jeśli argumentami są dwa rejestry to muszą one być tego samego rozmiaru." << endl;
		cout << endl;
	}
	else if (arg == "ADD") {
		cout << endl << "ADD" << endl << endl;
		cout << "Instrukcja służąca do dodawania wartości obu argumentów i umieszczenia wyniku w pierwszym z nich." << endl;
		cout << "Składnia wygląda w sposób następujący:" << endl << endl;
		cout << "ADD ARG1, ARG2" << endl << endl;
		cout << "gdzie:" << endl;
		cout << " - ARG1 określa rejestr, do którego dodajemy wartość drugiego argumentu" << endl;
		cout << " - ARG2 określa wartość dziesiętną lub rejestr, którego wartość dziesiętną chcemy dodać do rejestru podanego w ARG1" << endl;
		cout << "Jeśli argumentami są dwa rejestry to muszą one być tego samego rozmiaru." << endl;
		cout << endl;
	}
	else if (arg == "SUB") {
		cout << endl << "SUB" << endl << endl;
		cout << "Instrukcja służąca do odejmowania wartości obu argumentów i umieszczenia wyniku w pierwszym z nich." << endl;
		cout << "Składnia wygląda w sposób następujący:" << endl << endl;
		cout << "SUB ARG1, ARG2" << endl << endl;
		cout << "gdzie:" << endl;
		cout << " - ARG1 określa rejestr, od którego odejmujemy wartość drugiego argumentu" << endl;
		cout << " - ARG2 określa wartość dziesiętną lub rejestr, którego wartość dziesiętną chcemy odjąć od rejestru podanego w ARG1" << endl;
		cout << "Jeśli argumentami są dwa rejestry to muszą one być tego samego rozmiaru." << endl;
		cout << endl;
	}
	else if (arg == "POP") {
		cout << endl << "POP" << endl << endl;
		cout << "Instrukcja służąca do zdejmowania wartości z wierzchołka stosu." << endl;
		cout << "Składnia wygląda w sposób następujący:" << endl << endl;
		cout << "POP ARG" << endl << endl;
		cout << "gdzie:" << endl;
		cout << " - ARG określa rejestr, do którego zostanie wpisana wartość zdjęta z wierzchołka stosu." << endl;
		cout << endl;
	}
	else if (arg == "PUSH") {
		cout << endl << "PUSH" << endl << endl;
		cout << "Instrukcja służąca do zapamiętania wartości na wierzchołku stosu." << endl;
		cout << "Składnia wygląda w sposób następujący:" << endl << endl;
		cout << "PUSH ARG" << endl << endl;
		cout << "gdzie:" << endl;
		cout << " - ARG określa rejestr, którego wartość zostaje zapamiętana na stosie" << endl;
		cout << endl;
	}
	else if (arg == "file") {
		cout << endl << "file" << endl << endl;
		cout << "Komenda służąca do zmiany nazwy pliku do którego chcemy zapisać lub z którego chcemy odczytać program." << endl;
		cout << endl;
	}
	else if (arg == "clear") {
		cout << endl << "clear" << endl << endl;
		cout << "Komenda służąca do czyszczenia okna konsoli." << endl;
		cout << endl;
	}
	else if (arg == "INT") {
		cout << endl << "INT" << endl << endl;
		cout << "Instrukcja służąca do wywołania przerwania o numerze podanym jako argument." << endl;
		cout << "Składnia wygląda w sposób następujący:" << endl << endl;
		cout << "INT arg:" << endl << endl;
		cout << "gdzie:" << endl;
		cout << " - ARG określa numer przerwania. Może przyjmować wartości od 0 do 9." << endl;
		cout << "Aby przerwanie zadziałało, określone rejestry muszą mieć konkretną wartość." << endl;
		cout << endl;
	}
	else if (arg == "<-") {
		cout << endl << "<-" << endl << endl;
		cout << "Komenda służąca do wycofania się z aktualnie wykonywanej operacji." << endl;
		cout << "Przydaje się na przykład gdy chcemy zakończyć dopisywanie kodu do programu." << endl;
		cout << endl;
	}
	else if (arg == "exit") {
		cout << endl << "exit" << endl << endl;
		cout << "Komenda służąca do wyjścia z aplikacji." << endl;
		cout << endl;
	}
	else if (arg == "?") {
		cout << endl << "?" << endl << endl;
		cout << "Komenda służąca do wyświetlania opisu danej komendy lub instrukcji." << endl;
		cout << endl;
	}
	else if (arg == "instrukcje") {
		SetConsoleTextAttribute(color, FOREGROUND_GREEN | FOREGROUND_BLUE | FOREGROUND_RED);
		help("MOV", color);
		cout << "------------------------------------------------------------" << endl;
		help("ADD", color);
		cout << "------------------------------------------------------------" << endl;
		help("SUB", color);
		cout << "------------------------------------------------------------" << endl;
		help("PUSH", color);
		cout << "------------------------------------------------------------" << endl;
		help("POP", color);
		cout << "------------------------------------------------------------" << endl;
		help("INT", color);
		cout << endl;
	}
	else {
		Displayer("Wpisano niepoprawny argument.!\n", color, FOREGROUND_RED | FOREGROUND_INTENSITY);
	}
	SetConsoleTextAttribute(color, FOREGROUND_GREEN | FOREGROUND_BLUE | FOREGROUND_RED);
}

void show(vector<string> orders, vector<string> args1, vector<string> args2, HANDLE color) {
	//cout << endl;
	for (int i = 0; i < orders.size(); i++) {
		if (orders[i].substr(0, 3) == "INT")
			orderDisplayer(to_string(i + 1) + ".~	", color, FOREGROUND_BLUE, orders[i], args1[i]);
		else if ((orders[i] == "POP") || (orders[i] == "PUSH"))
			orderDisplayer(to_string(i + 1) + ".~	", color, FOREGROUND_BLUE, orders[i], args1[i]);
		else
			orderDisplayer(to_string(i + 1) + ".~	", color, FOREGROUND_BLUE, orders[i], args1[i], args2[i]);
	}
	//cout << endl;
}

void save(string title, vector<string> orders, vector<string> args1, vector<string> args2, HANDLE color) {
	fstream file;
	file.open(title + ".txt", ios::out);
	for (int i = 0; i < orders.size(); i++) {
		if (orders[i].substr(0, 3) == "INT") {
			file << orders[i] << args1[i] << endl;
		}
		else if ((orders[i].substr(0, 3) == "POP") || (orders[i].substr(0, 4) == "PUSH")) {
			file << orders[i] << " " << args1[i] << endl;
		}
		else {
			file << orders[i] << " " << args1[i] << ", " << args2[i] << endl;
		}
	}
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
		if (line.substr(0, 3) == "INT") {
			orders.push_back(line.substr(0, 3));
			args1.push_back(line.substr(3, 1));
			args2.push_back("void");
			continue;
		}
		else if (line.substr(0, 3) == "POP") {
			orders.push_back(line.substr(0, 3));
			args1.push_back(line.substr(4, line.length() - 4));
			args2.push_back("void");
		}
		else if (line.substr(0, 4) == "PUSH") {
			orders.push_back(line.substr(0, 4));
			args1.push_back(line.substr(5, line.length() - 5));
			args2.push_back("void");
		}
		else {
			orders.push_back(line.substr(0, 3));
			for (int i = 3; i < line.length(); i++) {
				if ((int)line[i] == 44) {
					args1.push_back(line.substr(4, i - 4));
					args2.push_back(line.substr(i + 2, line.length() - (i + 2)));
					break;
				}
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
	int order_handler = 0;
	Displayer("WPISYWANIE ROZKAZÓW\n", color, FOREGROUND_GREEN | FOREGROUND_BLUE | FOREGROUND_INTENSITY);
	while (ord_breaker) {
		Displayer("Podaj rozkaz\n", color, FOREGROUND_GREEN | FOREGROUND_BLUE);
		Displayer("$  ", color, FOREGROUND_GREEN | FOREGROUND_RED | FOREGROUND_INTENSITY);
		cin >> order;
		if (order == "<-") {												// <- cofnij
			break;
		}
		else if (order[0] == '?') {
			help(order.substr(1, order.length() - 1), color);
			continue;
		}
		else if (!dictionary(order, 1, order_handler)) {
			Displayer("Podano złą wartość\n", color, FOREGROUND_RED | FOREGROUND_INTENSITY);
			continue;
		}
		else {
			switch (order_handler) {
			case 1: {											// <- Wpisano MOV, ADD lub SUB
				bool arg1_breaker = true;
				while (arg1_breaker) {												// <- Wpisanie pierwszego argumentu
					orderDisplayer("Podaj pierwszy argument\n", color, FOREGROUND_GREEN | FOREGROUND_BLUE, order);
					Displayer("$  ", color, FOREGROUND_GREEN | FOREGROUND_RED | FOREGROUND_INTENSITY);
					cin >> arg1;
					if (arg1 == "<-") {												// <- cofnij
						break;
					}
					if (!dictionary(arg1, 2, order_handler)) {
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
							if (!dictionary(arg2, 3, order_handler, order, arg1)) {
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
				break;
			}
			case 2: {				// <- wpisano rozkaz INTxx
				bool arg1_breaker = true;
				while (arg1_breaker) {												// <- Wpisanie argumentu
					orderDisplayer("Podaj argument\n", color, FOREGROUND_GREEN | FOREGROUND_BLUE, order);
					Displayer("$  ", color, FOREGROUND_GREEN | FOREGROUND_RED | FOREGROUND_INTENSITY);
					cin >> arg1;
					if (arg1 == "<-") {												// <- cofnij
						break;
					}
					if (!dictionary(arg1, 5, order_handler)) {
						Displayer("Wpisano zły argument!\n", color, FOREGROUND_RED | FOREGROUND_INTENSITY);
						continue;
					}
					else {
						arg2 = "void";
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
						orderDisplayer("Wpisano następujący rozkaz:\n", color, FOREGROUND_GREEN | FOREGROUND_BLUE, order, arg1);
						arg1_breaker = false;
						break;
					}
				}
				break;
			}
			case 3: {											// <- wpisano rozkaz POP lub PUSH
				bool arg1_breaker = true;
				while (arg1_breaker) {												// <- Wpisanie argumentu
					orderDisplayer("Podaj argument\n", color, FOREGROUND_GREEN | FOREGROUND_BLUE, order);
					Displayer("$  ", color, FOREGROUND_GREEN | FOREGROUND_RED | FOREGROUND_INTENSITY);
					cin >> arg1;
					if (arg1 == "<-") {												// <- cofnij
						break;
					}
					if (!dictionary(arg1, 4, order_handler)) {
						Displayer("Wpisano zły argument!\n", color, FOREGROUND_RED | FOREGROUND_INTENSITY);
						continue;
					}
					else {
						arg2 = "void";
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
						orderDisplayer("Wpisano następujący rozkaz:\n", color, FOREGROUND_GREEN | FOREGROUND_BLUE, order, arg1);
						arg1_breaker = false;
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
		else if (input[0] == '?') {
			help(input.substr(1, input.length() - 1), color);
			continue;
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
		else if (input[0] == '?') {
			help(input.substr(1, input.length() - 1), color);
			continue;
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
		else if (newtitle[0] == '?') {
			help(newtitle.substr(1, newtitle.length() - 1), color);
			continue;
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

void interrupts(int id)
{
	switch (id)
	{
	case 1:
	{
		//system request key pressed
		reg[0].H = 0x80;
		char key = getchar();
		if (key == 'P' || key == 'p')
			reg[0].L = 0x01;
		else reg[0].L = 0x00;

	}break;
	case 2:
	{
		//extended wait for keypress
		reg[0].H = getchar();
		reg[0].L = (unsigned char)reg[0].H;

	}break;
	case 3:
	{
		//sleep for microseconds (CX:DX)
		clock_t time_end;
		reg[0].overflow = true;
		int milliseconds = ((reg[2].H << 8 + reg[2].L) << 16) + (reg[3].H << 8 + reg[3].L);
		time_end = clock() + milliseconds * CLOCKS_PER_SEC / 1000;
		while (clock() < time_end);
		reg[0].overflow = false;

	}break;
	case 4:
	{
		time_t ti = 0;
		int t = time(&ti);
		int sec = t;
		int min = (t/60)%60;
		int hr = (min/60)%24;
		reg[0].L = sec;		//sec
		reg[0].H = min;	//min

		reg[1].L = hr;	//hr
		reg[1].H = 0;

	}break;
	case 5:
	{
		int cl = clock();
		switch (reg[0].L)		//AH - 0: start, 1- stop, val at B, AL: 0 - miliseconds, 1 - seconds
		{

		case 1: //second
			cl /= 1000;
		case 0://millisecond
		{
			if (reg[0].H == 0)
				stack[0] = cl;
			else
			{
				reg[1].L = (cl - stack[0]) % 256;
				reg[1].H = (cl - stack[0]) / 256;
			}
		}

		}
		//
	}
	break;
	case 6:
	{
		//print char from AL
		cout << reg[0].L << endl;

	}
	break;
	case 7:
	{
		//read char from keyboard to AL
		reg[0].L = getchar();
	}
	break;
	case 8:
	{
		//zero all regs
		for (int i = 0; i < 4; i++)
		{
			reg[i].L = 0;
			reg[i].H = 0;
			reg[i].overflow = 0;
		}
	}
	break;
	case 9:
	{
		//flush stack
		for (int i = 0; i < M; i++)
			stack[i] = 0;
	}
	break;
	case 0:
	{
		cout << "\a";
	}
	break;
	default:
		cout << "nie rozpoznano komendy";
	}
}

void execute(vector <string> coms, vector <string> args1, vector <string> args2, HANDLE color)
{

	bool step;
	string input;
	while (true) {
		SP = M - 1;
		bool good = true;
		Displayer("Podaj tryb\n", color, FOREGROUND_GREEN | FOREGROUND_BLUE);
		Displayer("$  ", color, FOREGROUND_GREEN | FOREGROUND_RED | FOREGROUND_INTENSITY);
		cin >> input;
		if (input == "<-") {
			break;
		}
		else if (input[0] == '?') {
			help(input.substr(1, input.length() - 1), color);
			continue;
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
			else if (command == "INT")com = 4;
			else if (command == "PUSH")com = 5;
			else if (command == "POP")com = 6;
			else com = 0;

			//translacja komendy na adres (pierwszy argument)
			//wybór rejestru, na którym przeprowadzona zostanie zadana operacja
			if (com != 4)
			{
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
				if (com != 5 && com != 6)
				{
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
				}
			}
			//jeśli flaga reg_addr2 nie została ustawiona, oznacza to, że drugi argument jest liczbą.
			if (!reg_addr&&com != 4&& com!=5 && com!=6)
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
			case 4:
				interrupts(stoi(arg1));
			break;
			case 5: //PUSH
				stack[SP] = (operand_ptr[0]->H *256) + operand_ptr[0]->L;
				SP--;
				break;
			case 6: //POP
				SP++;
				operand_ptr[0]->H = stack[SP] / 256;
				operand_ptr[0]->L = stack[SP] % 256;
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
		else if (input[0] == '?') {
			help(input.substr(1, input.length() - 1), color);
			continue;
		}
		else { Displayer("Wpisano nieprawidłową komendę\n", color, FOREGROUND_RED | FOREGROUND_INTENSITY); }
	}
}


int main() {
	HANDLE color;
	color = GetStdHandle(STD_OUTPUT_HANDLE);
	SetConsoleTextAttribute(color, FOREGROUND_GREEN | FOREGROUND_BLUE | FOREGROUND_RED);
	console(color);
}
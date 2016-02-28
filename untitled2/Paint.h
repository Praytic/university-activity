#include <iostream>
#include <fstream>

line Make_Line(int x1, int y1, int x2, int y2) {
	line l = { { x1, y1 }, { x2, y2 } };
	return l;
}

System::Void Make_House(point p, System::Collections::Generic::List<line>^ lines) {
	lines->Add(Make_Line(p.x, p.y, p.x + 130, p.y));
	lines->Add(Make_Line(p.x, p.y + 150, p.x + 130, p.y + 150));
	lines->Add(Make_Line(p.x, p.y, p.x, p.y + 150));
	lines->Add(Make_Line(p.x + 130, p.y, p.x + 130, p.y + 150));
	lines->Add(Make_Line(p.x + 60, p.y + 120, p.x + 80, p.y + 120));
	lines->Add(Make_Line(p.x + 60, p.y + 120, p.x + 60, p.y + 150));
	lines->Add(Make_Line(p.x + 80, p.y + 120, p.x + 80, p.y + 150));
}

System::Void Make_Window(point p, System::Collections::Generic::List<line>^ lines) {
	lines->Add(Make_Line(p.x, p.y, p.x, p.y - 30));
	lines->Add(Make_Line(p.x, p.y, p.x + 10, p.y));
	lines->Add(Make_Line(p.x + 10, p.y, p.x + 10, p.y - 30));
	lines->Add(Make_Line(p.x, p.y - 30, p.x + 10, p.y - 30));
}

System::Void Make_Balcon(point p, System::Collections::Generic::List<line>^ lines) {
	lines->Add(Make_Line(p.x, p.y, p.x, p.y - 10));
	lines->Add(Make_Line(p.x, p.y, p.x + 30, p.y));
	lines->Add(Make_Line(p.x + 30, p.y, p.x + 30, p.y - 10));
	lines->Add(Make_Line(p.x, p.y - 10, p.x + 30, p.y - 10));
	lines->Add(Make_Line(p.x + 10, p.y - 10, p.x + 20, p.y - 10));
	lines->Add(Make_Line(p.x + 10, p.y - 10, p.x + 10, p.y - 30));
	lines->Add(Make_Line(p.x + 20, p.y - 10, p.x + 20, p.y - 30));
	lines->Add(Make_Line(p.x + 10, p.y - 30, p.x + 20, p.y - 30));
}

System::Void Make_Asset(point p, System::Collections::Generic::List<line>^ lines) {
	lines->Add(Make_Line(p.x, p.y, p.x, p.y - 5));
	lines->Add(Make_Line(p.x, p.y, p.x + 40, p.y));
	lines->Add(Make_Line(p.x + 40, p.y, p.x + 40, p.y - 5));
	lines->Add(Make_Line(p.x, p.y - 5, p.x + 40, p.y - 5));
	lines->Add(Make_Line(p.x + 20, p.y - 5, p.x + 20, p.y - 20));
	lines->Add(Make_Line(p.x, p.y - 20, p.x + 20, p.y - 30));
	lines->Add(Make_Line(p.x + 40, p.y - 20, p.x + 20, p.y - 30));
	lines->Add(Make_Line(p.x, p.y - 20, p.x + 40, p.y - 20));
}

System::Collections::Generic::List<line>^ GenerateSourceImage() {
	System::Collections::Generic::List<line>^ lines;
	point house = { 80, 0 },
		window1 = { 100, 140 },
		window2 = { 180, 140 },
		balcon1 = { 90, 90 },
		balcon2 = { 130, 90 },
		balcon3 = { 170, 90 },
		balcon4 = { 90, 40 },
		balcon5 = { 130, 40 },
		balcon6 = { 170, 40 },
		asset = { 20, 150 };
	Make_House(house, lines);
	Make_Window(window1, lines);
	Make_Window(window2, lines);
	Make_Balcon(balcon1, lines);
	Make_Balcon(balcon2, lines);
	Make_Balcon(balcon3, lines);
	Make_Balcon(balcon4, lines);
	Make_Balcon(balcon5, lines);
	Make_Balcon(balcon6, lines);
	Make_Asset(asset, lines);
	return lines;
}
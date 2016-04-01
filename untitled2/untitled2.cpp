// untitled2.cpp: главный файл проекта.
#include "stdafx.h"
#include "Transform.h"
#include "Paint.h"
#include "Form1.h"

using namespace untitled2;

[STAThreadAttribute]
int main(array<System::String ^> ^args)
{
	// Включение визуальных эффектов Windows XP до создания каких-либо элементов управления
	Application::EnableVisualStyles();
	Application::SetCompatibleTextRenderingDefault(false); 

	// Создание главного окна и его запуск
	Application::Run(gcnew Form1());
	return 0;
}

// untitled2.cpp: ������� ���� �������.
#include "stdafx.h"
#include "Transform.h"
#include "Paint.h"
#include "Form1.h"

using namespace untitled2;

[STAThreadAttribute]
int main(array<System::String ^> ^args)
{
	// ��������� ���������� �������� Windows XP �� �������� �����-���� ��������� ����������
	Application::EnableVisualStyles();
	Application::SetCompatibleTextRenderingDefault(false); 

	// �������� �������� ���� � ��� ������
	Application::Run(gcnew Form1());
	return 0;
}

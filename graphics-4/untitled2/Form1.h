#pragma once

#include <msclr/marshal_cppstd.h>

namespace untitled2 {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Сводка для Form1
	/// </summary>
	public ref class Form1 : public System::Windows::Forms::Form
	{
	private: System::Windows::Forms::Button^  btnUpload;

	private: point utmost;
			 point center;

	public:
		Form1(void)
		{
			InitializeComponent();
			System::Drawing::Rectangle rect = Form::ClientRectangle;
			point center = { rect.Width / 2, rect.Height / 2 };
			point utmost = { rect.Width, rect.Height };
			this->center = center;
			this->utmost = utmost;
		}

	protected:
		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		~Form1()
		{
			if (components)
			{
				delete components;
			}
		}

	private: System::Collections::Generic::List<line> lines;
			 bool drawNames;
			 float left, right, top, bottom;
			 float Wcx, Wcy, Wx, Wy;
			 float Vcx, Vcy, Vx, Vy;

	private: System::Windows::Forms::Button^  btnOpen;

	private: System::Windows::Forms::OpenFileDialog^  openFileDialog;
			 System::Windows::Forms::SaveFileDialog^  saveFileDialog;



			 /// <summary>
			 /// Требуется переменная конструктора.
			 /// </summary>
			 System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
			 /// <summary>
			 /// Обязательный метод для поддержки конструктора - не изменяйте
			 /// содержимое данного метода при помощи редактора кода.
			 /// </summary>
			 void InitializeComponent(void)
			 {
				 this->btnOpen = (gcnew System::Windows::Forms::Button());
				 this->openFileDialog = (gcnew System::Windows::Forms::OpenFileDialog());
				 this->saveFileDialog = (gcnew System::Windows::Forms::SaveFileDialog());
				 this->btnUpload = (gcnew System::Windows::Forms::Button());
				 this->SuspendLayout();
				 // 
				 // btnOpen
				 // 
				 this->btnOpen->ImageAlign = System::Drawing::ContentAlignment::BottomRight;
				 this->btnOpen->Location = System::Drawing::Point(12, 12);
				 this->btnOpen->Name = L"btnOpen";
				 this->btnOpen->Size = System::Drawing::Size(75, 23);
				 this->btnOpen->TabIndex = 0;
				 this->btnOpen->Text = L"Открыть";
				 this->btnOpen->UseVisualStyleBackColor = true;
				 this->btnOpen->Click += gcnew System::EventHandler(this, &Form1::button1_Click);
				 // 
				 // openFileDialog
				 // 
				 this->openFileDialog->DefaultExt = L"txt";
				 this->openFileDialog->FileName = L"coordinates.txt";
				 this->openFileDialog->Filter = L"Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
				 this->openFileDialog->Title = L"Открыть файл";
				 // 
				 // saveFileDialog
				 // 
				 this->saveFileDialog->DefaultExt = L"txt";
				 this->saveFileDialog->FileName = L"coordinates.txt";
				 this->saveFileDialog->Filter = L"Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
				 this->saveFileDialog->Title = L"Сгенерировать координаты";
				 // 
				 // btnUpload
				 // 
				 this->btnUpload->ImageAlign = System::Drawing::ContentAlignment::BottomLeft;
				 this->btnUpload->Location = System::Drawing::Point(12, 41);
				 this->btnUpload->Name = L"btnUpload";
				 this->btnUpload->Size = System::Drawing::Size(75, 23);
				 this->btnUpload->TabIndex = 1;
				 this->btnUpload->Text = L"Выгрузить";
				 this->btnUpload->UseVisualStyleBackColor = true;
				 this->btnUpload->Click += gcnew System::EventHandler(this, &Form1::button1_Click_1);
				 // 
				 // Form1
				 // 
				 this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
				 this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
				 this->ClientSize = System::Drawing::Size(789, 424);
				 this->Controls->Add(this->btnUpload);
				 this->Controls->Add(this->btnOpen);
				 this->KeyPreview = true;
				 this->MinimumSize = System::Drawing::Size(50, 50);
				 this->Name = L"Form1";
				 this->RightToLeft = System::Windows::Forms::RightToLeft::No;
				 this->Text = L"Form1";
				 this->Load += gcnew System::EventHandler(this, &Form1::Form1_Load);
				 this->Paint += gcnew System::Windows::Forms::PaintEventHandler(this, &Form1::Form1_Paint);
				 this->KeyDown += gcnew System::Windows::Forms::KeyEventHandler(this, &Form1::Form1_KeyDown);
				 this->Resize += gcnew System::EventHandler(this, &Form1::Form1_Resize);
				 this->ResumeLayout(false);

			 }
#pragma endregion
	private: System::Void RefreshBorderCoordinates() {
				 left = 20;
				 right = 20;
				 top = 20;
				 bottom = 20;
				 Wcx = left;
				 Wcy = Form::ClientRectangle.Height - bottom;
				 Wx  = Form::ClientRectangle.Width  - left - right;
				 Wy  = Form::ClientRectangle.Height - top - bottom;
			 }
	private: System::Void Restore_Image() {
				 unit(T);
				 mat R, T1;
				 reflectHorizontally(utmost.y, R);
				 times(R, T, T1);
				 set(T1, T);
			 }
	private: System::Void Form1_Load(System::Object^  sender, System::EventArgs^  e) {
				 drawNames = false;
				 lines.Clear();
				 unit(T);
				 RefreshBorderCoordinates();
			 }
	private: System::Void Form1_Resize(System::Object^  sender, System::EventArgs^  e) {
				 System::Drawing::Rectangle rect = Form::ClientRectangle;
				 point center = { rect.Width / 2, rect.Height / 2 };
				 point utmost = { rect.Width, rect.Height };
				 this->center = center;
				 this->utmost = utmost;

				 float oldWx = Wx, oldWy = Wy;
				 mat R, T1;
				 RefreshBorderCoordinates();
				 scaleOverPoint(Wx / oldWx, Wy / oldWy, Wcx, top, R);
				 times(R, T, T1);
				 set(T1, T);	

				 this->Refresh();
			 }
	private: System::Void Form1_Paint(System::Object^  sender, System::Windows::Forms::PaintEventArgs^  e) {
				 Graphics^ g = e->Graphics;
				 g->Clear(Color::White);
				 Pen^ blackPen = gcnew Pen(Color::Black, 1);
				 Pen^ rectPen = gcnew Pen(Color::Red, 2);
				 System::Drawing::Font^ font = gcnew System::Drawing::Font("Arial", 8);
				 SolidBrush^ fontBrush = gcnew SolidBrush(Color::Black);

				 g->DrawRectangle(rectPen, Wcx, top, Wx, Wy);

				 point Pmin, Pmax;

				Pmin.x = Wcx;
				Pmin.y = Wcy-Wy;
				Pmax.x = Wcx + Wx;
				Pmax.y = Wcy;

				 for (int i = 0; i < lines.Count; i++) {
					 vec A, B;
					 point2vec(lines[i].start, A);
					 point2vec(lines[i].end, B);
					 vec A1, B1;
					 timesMatVec(T,A,A1);
					 timesMatVec(T,B,B1);
					 point a, b;
					 vec2point(A1, a);
					 vec2point(B1, b);

					if (clip(a, b, Pmin, Pmax)) {
						 g->DrawLine(blackPen, a.x, a.y, b.x, b.y);
					}

					 if (drawNames) {
						 g->DrawString(lines[i].name, font, fontBrush, (a.x+((b.x-a.x)/2)), (a.y+((b.y-a.y)/2)));
					 }
				 }	
			 }
	private: System::Void button1_Click(System::Object^  sender, System::EventArgs^  e) {
				 if (this->openFileDialog->ShowDialog() ==
					 System::Windows::Forms::DialogResult::OK) {
						 wchar_t fileName[1024];
						 for (int i = 0; i < openFileDialog->FileName->Length; i++) {
							 fileName[i] = openFileDialog->FileName[i];
						 }
						 fileName[openFileDialog->FileName->Length] = '\0';
						 std::ifstream in;
						 in.open(fileName);
						 if ( in.is_open() ) {
							 lines.Clear();
							 unit(T);
							 std::string str;
							 getline (in, str);
							 if (in) {
								 if ((str.find_first_not_of(" \t\r\n") != std::string::npos)
									 && (str[0] != '#')) {
										 std::stringstream s(str);
										 line l;
										 float oVcx, oVcy, oVx, oVy;
										 s >> oVcx >> oVcy >> oVx >> oVy;
										 Vcx = oVcx;
										 Vcy = oVcy;
										 Vx = oVx;
										 Vy = oVy;
								 }
								 getline(in, str);
							 }
							 while (in) {
								 if ((str.find_first_not_of(" \t\r\n") != std::string::npos)
									 && (str[0] != '#')) {
										 std::stringstream s(str);
										 line l;
										 s >> l.start.x >>  l.start.y >> l.end.x >> l.end.y;
										 std::string linename;
										 s >> linename;
										 l.name = gcnew String(linename.c_str());
										 lines.Add(l);
								 }
								 getline(in, str);
							 }
						 }
						 Restore_Image();
						 frame(Vx, Vy, Vcx, Vcy, Wx, Wy, Wcx, Wcy, T);
						 this->Refresh();
				 }
			 }
	private: System::Void button1_Click_1(System::Object^  sender, System::EventArgs^  e) {
				 if (this->saveFileDialog->ShowDialog() ==
					 System::Windows::Forms::DialogResult::OK) {
						 wchar_t fileName[1024];
						 for (int i = 0; i < saveFileDialog->FileName->Length; i++)
							 fileName[i] = saveFileDialog->FileName[i];
						 fileName[saveFileDialog->FileName->Length] = '\0';
						 std::ofstream out;
						 out.open(fileName);
						 if ( out.is_open() ) {
							 float oVcx = Vcx,
								 oVcy = Vcy,
								 oVx = Vx,
								 oVy = Vy;
							out << oVcx << ' ' << oVcy << ' ' 
								<< oVx << ' ' << oVy << '\n';
							 for (int i = 0; i < lines.Count; i++) {
								 vec A, B;
								 point2vec(lines[i].start, A);
								 point2vec(lines[i].end, B);
								 vec A1, B1;
								 timesMatVec(T,A,A1);
								 timesMatVec(T,B,B1);
								 point a, b;
								 vec2point(A1, a);
								 vec2point(B1, b);
								std::string nameOut = msclr::interop::marshal_as<std::string>(lines[i].name);
								 out << a.x << ' ' << a.y << ' ' 
									 << b.x << ' ' << b.y << ' '
									 << nameOut << '\n';
							 }
						 }
						 this->Refresh();
				 }
			 }
	private: System::Void Form1_KeyDown(System::Object^  sender, System::Windows::Forms::KeyEventArgs^  e) {
				 mat R, T1;
				 switch(e->KeyCode) {
				 case Keys::W :			// move up
					 move(0, -2, R);	
					 break;	
				 case Keys::S :			// move down
					 move(0, 2, R);		
					 break;
				 case Keys::A :			// move left
					 move(-2, 0, R);	
					 break;
				 case Keys::D :			// move right
					 move(2, 0, R);		
					 break;
				 case Keys::T :			// move up long
					 move(0, -20, R);	
					 break;	
				 case Keys::G :			// move down long
					 move(0, 20, R);	
					 break;
				 case Keys::F :			// move left long
					 move(-20, 0, R);	
					 break;
				 case Keys::H :			// move right long
					 move(20, 0, R);	
					 break;
				 case Keys::E :			// rotate clockwise
					 rotateClockwisePivot(0.05, R);	
					 break;
				 case Keys::Q :			// rotate counterclockwise
					 rotateCounterclockwisePivot(0.05, R);	
					 break;
				 case Keys::R :			// rotate clockwise center
					 rotateClockwisePoint(0.05, center.x, center.y, R);
					 break;
				 case Keys::Y :			// rotate counterclockwise center
					 rotateCounterclockwisePoint(0.05, center.x, center.y, R);
					 break;
				 case Keys::U :			// reflect vertically center
					 reflectHorizontally(center.y, R);
					 break;
				 case Keys::J :			// refect horizontally center
					 reflectVertically(center.x, R);
					 break;
				 case Keys::X :			// scale increase
					 scaleOverPivot(1.1, R);		
					 break;
				 case Keys::Z :			// scale decrease
					 scaleOverPivot(0.9, R);		
					 break;
				 case Keys::C :			// scale increase center
					 scaleOverPoint(1.1, center.x, center.y, R);
					 break;
				 case Keys::V :			// scale decrease center
					 scaleOverPoint(0.9, center.x, center.y, R);
					 break;
				 case Keys::I :			// scale decrease horizontal
					 scaleHorizontally(0.9, center.y, R);
					 break;
				 case Keys::O :			// scale inscrease horizontal
					 scaleHorizontally(1.1, center.y, R);
					 break;
				 case Keys::K :			// scale decrease vertical
					 scaleVertically(0.9, center.x, R);	
					 break;
				 case Keys::L :			// scale increase vertical
					 scaleVertically(1.1, center.x, R);
					 break;
				 case Keys::Escape :	// reset image
					 unit(R);
					unit(T);
					 frame(Vx, Vy, Vcx, Vcy, Wx, Wy, Wcx, Wcy, T);
					 break;
				 case Keys::P :
					 drawNames = !drawNames;
					 unit(R);
					 break;
				 default :
					 unit(R);
				 }
				 times(R, T, T1);
				 set(T1, T);
				 this->Refresh();
			 }
	};
}


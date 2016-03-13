#pragma once

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
	private: point center;

	public:
		Form1(void)
		{
			InitializeComponent();
			Rectangle rect = Form::ClientRectangle;
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
	private: float left, right, top, bottom;
	private: float Wcx, Wcy, Wx, Wy;
	private: float Vcx, Vcy, Vx, Vy;

	private: System::Windows::Forms::Button^  btnOpen;

	private: System::Windows::Forms::OpenFileDialog^  openFileDialog;
	private: System::Windows::Forms::SaveFileDialog^  saveFileDialog;



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
				 this->ClientSize = System::Drawing::Size(284, 262);
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
				 mat N,T1,T2;
				 move(0, -utmost.y, N);
				 times(N,T,T1);
				 scaleVertically(-1, N);
				 times(N,T1,T2);
				 set(T2, T);
			 }
	private: System::Void Form1_Load(System::Object^  sender, System::EventArgs^  e) {
				 lines.Clear();
				 unit(T);
				 RefreshBorderCoordinates();
			 }
	private: System::Void Form1_Resize(System::Object^  sender, System::EventArgs^  e) {
				 Rectangle rect = Form::ClientRectangle;
				 point center = { rect.Width / 2, rect.Height / 2 };
				 point utmost = { rect.Width, rect.Height };
				 this->center = center;
				 this->utmost = utmost;

				 float oldWx = Wx, oldWy = Wy;
				 mat R, T1;
				 RefreshBorderCoordinates();

				 move(-Wcx, top, R);
				times(R, T, T1);
				set(T1, T);
				scale(Wx / oldWx, Wy / oldWy, R);		
				times(R, T, T1);
				set(T1, T);	
				move(Wcx, top, R);	
				times(R, T, T1);
				set(T1, T);	

				 this->Refresh();
			 }
	private: System::Void Form1_Paint(System::Object^  sender, System::Windows::Forms::PaintEventArgs^  e) {
				 Graphics^ g = e->Graphics;
				 g->Clear(Color::White);
				 Pen^ blackPen = gcnew Pen(Color::Black, 1);
				 Pen^ rectPen = gcnew Pen(Color::Red, 2);

				 g->DrawRectangle(rectPen, Wcx, top, Wx, Wy);
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
					 g->DrawLine(blackPen, a.x, a.y, b.x, b.y);
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
						 frame(Vx, Vy, Vcx, Vcy, Wx, Wy, Wcx, Wcy, T, utmost);
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
								 out << a.x << ' ' << a.y << ' ' 
									 << b.x << ' ' << b.y << '\n';
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
					 rotate(0.05, R);	
					 break;
				 case Keys::Q :			// rotate counterclockwise
					 rotate(-0.05, R);	
					 break;
				 case Keys::R :			// rotate clockwise center
					 move(-center.x, -center.y, R);
					 times(R, T, T1);
					 set(T1, T);
					 rotate(0.05, R);
					 times(R, T, T1);
					 set(T1, T);
					 move(center.x, center.y, R);
					 break;
				 case Keys::Y :			// rotate counterclockwise center
					 move(-center.x, -center.y, R);
					 times(R, T, T1);
					 set(T1, T);
					 rotate(-0.05, R);
					 times(R, T, T1);
					 set(T1, T);
					 move(center.x, center.y, R);
					 break;
				 case Keys::U :			// reflect vertically center
					 scaleVertically(-1, R);
					 times(R,T,T1);
					 set(T1,T);
					 move(0, utmost.y, R);
					 break;
				 case Keys::J :			// refect horizontally center
					 scaleHorizontally(-1, R);
					 times(R,T,T1);
					 set(T1,T);
					 move(utmost.x, 0, R);
					 break;
				 case Keys::X :			// scale increase
					 scale(1.1, R);		
					 break;
				 case Keys::Z :			// scale decrease
					 scale(0.9, R);		
					 break;
				 case Keys::C :			// scale increase center
					 move(-center.x, -center.y, R);
					 times(R, T, T1);
					 set(T1, T);
					 scale(1.1, R);		
					 times(R, T, T1);
					 set(T1, T);	
					 move(center.x, center.y, R);	
					 break;
				 case Keys::V :			// scale decrease center
					 move(-center.x, -center.y, R);
					 times(R, T, T1);
					 set(T1, T);
					 scale(0.9, R);		
					 times(R, T, T1);
					 set(T1, T);	
					 move(center.x, center.y, R);	
					 break;
				 case Keys::I :			// scale decrease horizontal
					 move(-center.x, -center.y, R);
					 times(R, T, T1);
					 set(T1, T);
					 scaleHorizontally(0.9, R);
					 times(R, T, T1);
					 set(T1, T);	
					 move(center.x, center.y, R);	
					 break;
				 case Keys::O :			// scale inscrease horizontal
					 move(-center.x, -center.y, R);
					 times(R, T, T1);
					 set(T1, T);
					 scaleHorizontally(1.1, R);
					 times(R, T, T1);
					 set(T1, T);	
					 move(center.x, center.y, R);	
					 break;
				 case Keys::K :			// scale decrease vertical
					 move(-center.x, -center.y, R);
					 times(R, T, T1);
					 set(T1, T);
					 scaleVertically(0.9, R);
					 times(R, T, T1);
					 set(T1, T);	
					 move(center.x, center.y, R);		
					 break;
				 case Keys::L :			// scale increase vertical
					 move(-center.x, -center.y, R);
					 times(R, T, T1);
					 set(T1, T);
					 scaleVertically(1.1, R);
					 times(R, T, T1);
					 set(T1, T);	
					 move(center.x, center.y, R);	
					 break;
				 case Keys::Escape :	// reset image
					 unit(R);
					 frame(Vx, Vy, Vcx, Vcy, Wx, Wy, Wcx, Wcy, T, utmost);
					 Restore_Image();
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


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
	private: point utmost, center;
	private: System::Windows::Forms::Button^  btnOpen;
    private: System::Windows::Forms::Button^  button1;


	private: System::Windows::Forms::Panel^  panel1;


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


	private: System::Windows::Forms::OpenFileDialog^  openFileDialog;
			 System::Windows::Forms::SaveFileDialog^  saveFileDialog;

    private: void DrawFigure(Graphics^ g, Pen^ pen)
    {
        System::Drawing::Font^ font = gcnew System::Drawing::Font("Arial", 8);
        SolidBrush^ fontBrush = gcnew SolidBrush(Color::Black);
		float scale = 0.4;
        for (int i = 0; i < lines.Count; i++) {
            g->DrawLine(pen, lines[i].start.x * scale, lines[i].start.y * scale, lines[i].end.x * scale, lines[i].end.y * scale);

            if (drawNames) {
               // g->DrawString(lines[i].name, font, fontBrush, (lines[i].start.x + ((lines[i].end.x - lines[i].start.x) / 2)), (lines[i].start.y + ((lines[i].end.y - lines[i].start.y) / 2)));
            }
        }
    }


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
                 this->openFileDialog = (gcnew System::Windows::Forms::OpenFileDialog());
                 this->saveFileDialog = (gcnew System::Windows::Forms::SaveFileDialog());
                 this->btnOpen = (gcnew System::Windows::Forms::Button());
                 this->panel1 = (gcnew System::Windows::Forms::Panel());
                 this->button1 = (gcnew System::Windows::Forms::Button());
                 this->SuspendLayout();
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
                 // btnOpen
                 // 
                 this->btnOpen->ImageAlign = System::Drawing::ContentAlignment::BottomRight;
                 this->btnOpen->Location = System::Drawing::Point(12, 12);
                 this->btnOpen->Name = L"btnOpen";
                 this->btnOpen->Size = System::Drawing::Size(87, 23);
                 this->btnOpen->TabIndex = 0;
                 this->btnOpen->Text = L"Координаты";
                 this->btnOpen->UseVisualStyleBackColor = true;
                 this->btnOpen->Click += gcnew System::EventHandler(this, &Form1::button1_Click);
                 // 
                 // panel1
                 // 
                 this->panel1->AutoSize = true;
                 this->panel1->AutoSizeMode = System::Windows::Forms::AutoSizeMode::GrowAndShrink;
                 this->panel1->Location = System::Drawing::Point(12, 12);
                 this->panel1->Name = L"panel1";
                 this->panel1->Size = System::Drawing::Size(0, 0);
                 this->panel1->TabIndex = 3;
                 // 
                 // button1
                 // 
                 this->button1->ImageAlign = System::Drawing::ContentAlignment::BottomRight;
                 this->button1->Location = System::Drawing::Point(105, 12);
                 this->button1->Name = L"button1";
                 this->button1->Size = System::Drawing::Size(75, 23);
                 this->button1->TabIndex = 4;
                 this->button1->Text = L"Команды";
                 this->button1->UseVisualStyleBackColor = true;
                 this->button1->Click += gcnew System::EventHandler(this, &Form1::button1_Click_1);
                 // 
                 // Form1
                 // 
                 this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
                 this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
                 this->ClientSize = System::Drawing::Size(789, 424);
                 this->Controls->Add(this->button1);
                 this->Controls->Add(this->panel1);
                 this->Controls->Add(this->btnOpen);
                 this->KeyPreview = true;
                 this->MinimumSize = System::Drawing::Size(400, 200);
                 this->Name = L"Form1";
                 this->RightToLeft = System::Windows::Forms::RightToLeft::No;
                 this->Text = L"Form1";
                 this->Load += gcnew System::EventHandler(this, &Form1::Form1_Load);
                 this->Paint += gcnew System::Windows::Forms::PaintEventHandler(this, &Form1::Form1_Paint);
                 this->KeyDown += gcnew System::Windows::Forms::KeyEventHandler(this, &Form1::Form1_KeyDown);
                 this->Resize += gcnew System::EventHandler(this, &Form1::Form1_Resize);
                 this->ResumeLayout(false);
                 this->PerformLayout();

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
                
                 System::Drawing::Rectangle rect = System::Drawing::Rectangle(Wcx, top, Wx, Wy);
                 g->DrawRectangle(rectPen, rect);
                 g->Clip = gcnew System::Drawing::Region(rect);


				 for (int i = 0; i < matrices.size(); i++) {
					mat C;
					times(T, matrices[i], C);
					g->Transform = gcnew System::Drawing::Drawing2D::Matrix(C[0][0], C[1][0], C[0][1], C[1][1], C[0][2], C[1][2]);
					DrawFigure(g, blackPen);
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
						 frame(Vx, Vy, Vcx, Vcy, Wx, Wy, Wcx, Wcy, T);
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

    private: System::Void button1_Click_1(System::Object^  sender, System::EventArgs^  e) {
        if (this->openFileDialog->ShowDialog() ==
            System::Windows::Forms::DialogResult::OK) {
            wchar_t fileName[1024];
            for (int i = 0; i < openFileDialog->FileName->Length; i++)
            {
                fileName[i] = openFileDialog->FileName[i];
            }
            fileName[openFileDialog->FileName->Length] = '\0';
            std::ifstream in;
            in.open(fileName);
            if (in.is_open()) {
                matrices.clear();
                std::stack<mat> matStack;
                mat K;
                unit(K);
                unit(T);
                std::string str;
                getline(in, str);
                while (in) {
                    if ((str.find_first_not_of(" \t\r\n") != std::string::npos)
                        && (str[0] != '#')) {
                        std::stringstream s(str);
                        std::string cmd;
                        s >> cmd;
                        if (cmd == "frame") {
                            line l;
                            s >> l.start.x >> l.start.y >> l.end.x >> l.end.y;
                            Vcx = l.start.x;
                            Vcy = l.start.y;
                            Vx = l.end.x;
                            Vy = l.end.y;
                            frame(Vx, Vy, Vcx, Vcy, Wx, Wy, Wcx, Wcy, T);
                        }
                        else if (cmd == "figure") {
                            matrices.push_back(K);
                        }
                        else if (cmd == "pushTransform") {
                            matStack.push(K);
                        }
                        else if (cmd == "popTransform") {
                            K = matStack.top();
                            matStack.pop();
                        }
                        else if (cmd == "translate") {
                            float Tx, Ty;
                            s >> Tx >> Ty;
                            mat C, C1;
                            move(Tx, Ty, C);
                            times(K, C, C1);
                            K = C1;
                        }
                        else if (cmd == "scale") {
                            float S;
                            s >> S;
                            mat C, C1;
                            scaleOverPivot(S, C);
                            times(K, C, C1);
                            K = C1;
                        }
                        else if (cmd == "rotate") {
                            float Phi;
                            s >> Phi;
                            float pi = 3.1415926535;
                            float PhiR = Phi*(pi / 180);
                            mat C, C1;
                            rotateCounterclockwisePivot(PhiR, C);
                            times(K, C, C1);
                            K = C1;
                        }
                    }
                    getline(in, str);
                }
            }
            this->Refresh();
        }
        }
};
}


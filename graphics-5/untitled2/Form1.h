#pragma once

#include <cmath>

namespace untitled2 {

    using namespace System;
    using namespace System::ComponentModel;
    using namespace System::Collections;
    using namespace System::Windows::Forms;
    using namespace System::Data;
    using namespace System::Drawing;

    /// <summary>
    /// —водка дл€ Form1
    /// </summary>
    public ref class Form1 : public System::Windows::Forms::Form
    {
    public:
        Form1(void)
        {
            InitializeComponent();
            //
            //TODO: добавьте код конструктора
            //
        }

    protected:
        /// <summary>
        /// ќсвободить все используемые ресурсы.
        /// </summary>
        ~Form1()
        {
            if (components)
            {
                delete components;
            }
        }
    private:
        float left, right, top, bottom;
        float Wcx, Wcy, Wx, Wy;
        float Vcx, Vcy, Vx, Vy;
        float oldVcx, oldVcy, oldVx, oldVy;
        float L, K;
        float oldL, oldK;
        bool drawNames;

    private: System::Windows::Forms::OpenFileDialog^  openFileDialog;




    private:
        /// <summary>
        /// “ребуетс€ переменна€ конструктора.
        /// </summary>
        System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
        /// <summary>
        /// ќб€зательный метод дл€ поддержки конструктора - не измен€йте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        void InitializeComponent(void)
        {
            this->openFileDialog = (gcnew System::Windows::Forms::OpenFileDialog());
            this->SuspendLayout();
            // 
            // Form1
            // 
            this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
            this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
            this->ClientSize = System::Drawing::Size(584, 562);
            this->KeyPreview = true;
            this->MinimumSize = System::Drawing::Size(100, 150);
            this->Name = L"Form1";
            this->Text = L"Form1";
            this->Load += gcnew System::EventHandler(this, &Form1::Form1_Load);
            this->Paint += gcnew System::Windows::Forms::PaintEventHandler(this, &Form1::Form1_Paint);
            this->KeyDown += gcnew System::Windows::Forms::KeyEventHandler(this, &Form1::Form1_KeyDown);
            this->Resize += gcnew System::EventHandler(this, &Form1::Form1_Resize);
            this->ResumeLayout(false);

        }
#pragma endregion

    private: System::Void Form1_Load(System::Object^  sender, System::EventArgs^  e) {
        left = 40;
        right = 40;
        top = 40;
        bottom = 40;
        Vcx = -5; Vcy = -5; Vx = 10; Vy = 10;
        oldVcx = Vcx; oldVcy = Vcy; oldVx = Vx; oldVy = Vy;

        Wcx = left;
        Wcy = Form::ClientRectangle.Height - bottom;
        Wx = Form::ClientRectangle.Width - left - right;
        Wy = Form::ClientRectangle.Height - top - bottom;
        L = 10; K = 10;
        oldL = L; oldK = K;
    }
    private: System::Void Form1_Paint(System::Object^  sender, System::Windows::Forms::PaintEventArgs^  e) {
        Graphics^ g = e->Graphics;
        g->Clear(Color::White);
        Rectangle rect = Form::ClientRectangle;

        Pen^ rectPen = gcnew Pen(Color::Red, 3);
        Pen^ grayPen = gcnew Pen(Color::LightGray, 1);
        Pen^ coo = gcnew Pen(Color::Red, 1);
        Pen^ blackPen = gcnew Pen(Color::Black, 2);
        System::Drawing::Font^ drawFont = gcnew System::Drawing::Font("Arial", 8);
        SolidBrush^ drawBrush = gcnew SolidBrush(Color::Black);

        point Pmin, Pmax;
        Pmin.x = left;
        Pmin.y = top;
        Pmax.x = Form::ClientRectangle.Width - right;
        Pmax.y = Form::ClientRectangle.Height - bottom;


        g->DrawRectangle(rectPen, Wcx, top, Wx, Wy);

        float X, Y;
        point a, b;
        for (int i = 1;i < L;i++) {
            X = (Vx / (L))*i + Vcx;
            a.x = b.x = ((X - Vcx) / Vx)*Wx + Wcx;
            a.y = Pmin.y + 2; b.y = Pmax.y - 2;
            
                g->DrawLine(grayPen, a.x, a.y, b.x, b.y);

            g->DrawString(X.ToString("f"), drawFont, drawBrush, a.x - 7, top - 13);
        }
        for (int i = 1;i < K;i++) {
            Y = (Vy / (K))*i + Vcy;
            a.y = b.y = Wcy - ((Y - Vcy) / Vy)*Wy;
            a.x = Pmin.x + 2; b.x = Pmax.x - 2;
            if ((int)(abs(Y / 0.01)) == 0)
                g->DrawLine(coo, a.x, a.y, b.x, b.y);
            else
                g->DrawLine(grayPen, a.x, a.y, b.x, b.y);

            g->DrawString(Y.ToString("f"), drawFont, drawBrush, 10, a.y - 7);
        }
        bool visible1, visible2;
        float x1 = Wcx, x = Vcx;
        float y1, y, y11;
        if (fexists(x)) {
            visible1 = true;
            y = f(x);
            y1 = Wcy - ((y - Vcy) / Vy)*Wy;
        }
        else visible1 = false;
        while (x < (Wcx + Wx)) {
            x = ((x1 + 1 - Wcx) / Wx)*Vx + Vcx;
            if (fexists(x)) {
                visible2 = true;
                y = f(x);
                y11 = Wcy - ((y - Vcy) / Vy)*Wy;
            }
            else visible2 = false;
            if (visible1 && visible2) {
                point a, b;
                a.x = x1; a.y = y1;
                b.x = x1 + 1; b.y = y11;
                if (clip(a, b, Pmin, Pmax))
                    g->DrawLine(blackPen, a.x, a.y, b.x, b.y);
            }
            x1 = x1 + 1; y1 = y11; visible1 = visible2;
        }
    }
    private: System::Void Form1_KeyDown(System::Object^  sender, System::Windows::Forms::KeyEventArgs^  e) {
        float scale = 0.01;
        float pixelX = (1 / Wx * Vx / scale) * scale ;
        float pixelY = (1 / Wy * Vy / scale) * scale ;

        switch (e->KeyCode)
        {
        case Keys::I: Vx -= 15*pixelX; Vcx +=15* pixelX ;
            break;
        case Keys::O: Vx +=10* pixelX; Vcx -= 10*pixelX;
            break;
        case Keys::K: Vy += 10*pixelY; Vcy -=10* pixelY ;
            break;
        case Keys::L: Vy -= 10*pixelY; Vcy +=10* pixelY ;
            break;
        case Keys::W: Vcy += pixelY;
            break;
        case Keys::S: Vcy -= pixelY;
            break;
        case Keys::A: Vcx -= pixelX;
            break;
        case Keys::D: Vcx += pixelX;
            break;
        case Keys::T: Vcy++;
            break;
        case Keys::G: Vcy--;
            break;
        case Keys::F: Vcx--;
            break;
        case Keys::H: Vcx++;
            break;
        case Keys::Q: if (L > 0) L--;
            break;
        case Keys::Z: if (K > 0) K--;
            break;
        case Keys::E: L++;
            break;
        case Keys::C: K++;
            break;
        case Keys::Escape:
            Vcx = oldVcx;
            Vcy = oldVcy;
            Vx = oldVx;
            Vy = oldVy;
            K = oldK;
            L = oldL;
            break;
        }
        this->Refresh();
    }
    private: System::Void Form1_Resize(System::Object^  sender, System::EventArgs^  e) {
        Wcx = left;
        Wcy = Form::ClientRectangle.Height - bottom;
        Wx = Form::ClientRectangle.Width - left - right;
        Wy = Form::ClientRectangle.Height - top - bottom;
        this->Refresh();
    }
    };
}

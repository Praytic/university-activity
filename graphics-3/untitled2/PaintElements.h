	private: System::Void Draw_House(Graphics^ g, Pen^ pen) {
				 g->DrawLine(pen, 80, 0, 210, 0);
				 g->DrawLine(pen, 80, 150, 210, 150);
				 g->DrawLine(pen, 80, 0, 80, 150);
				 g->DrawLine(pen, 210, 0, 210, 150);
				 g->DrawLine(pen, 140, 120, 160, 120);
				 g->DrawLine(pen, 140, 120, 140, 150);
				 g->DrawLine(pen, 160, 120, 160, 150);
			 }

	private: System::Void Draw_Window(Graphics^ g, Pen^ pen, int x, int y) {
				 g->DrawLine(pen, x, y, x, y - 30);
				 g->DrawLine(pen, x, y, x + 10, y);
				 g->DrawLine(pen, x + 10, y, x + 10, y - 30);
				 g->DrawLine(pen, x, y - 30, x + 10, y - 30);
			 }

	private: System::Void Draw_Balcon(Graphics^ g, Pen^ pen, int x, int y) {
				 g->DrawLine(pen, x, y, x, y - 10);
				 g->DrawLine(pen, x, y, x + 30, y);
				 g->DrawLine(pen, x + 30, y, x + 30, y - 10);
				 g->DrawLine(pen, x, y - 10, x + 30, y - 10);
				 g->DrawLine(pen, x + 10, y - 10, x + 20, y - 10);
				 g->DrawLine(pen, x + 10, y - 10, x + 10, y - 30);
				 g->DrawLine(pen, x + 20, y - 10, x + 20, y - 30);
				 g->DrawLine(pen, x + 10, y - 30, x + 20, y - 30);
			 }

	private: System::Void Draw_Asset(Graphics^ g, Pen^ pen, int x, int y) {
				 g->DrawLine(pen, x, y, x, y - 5);
				 g->DrawLine(pen, x, y, x + 40, y);
				 g->DrawLine(pen, x + 40, y, x + 40, y - 5);
				 g->DrawLine(pen, x, y - 5, x + 40, y - 5);

				 g->DrawLine(pen, x + 20, y - 5, x + 20, y - 20);

				 g->DrawLine(pen, x, y - 20, x + 20, y - 30);
				 g->DrawLine(pen, x + 40, y - 20, x + 20, y - 30);
				 g->DrawLine(pen, x, y - 20, x + 40, y - 20);
			 }
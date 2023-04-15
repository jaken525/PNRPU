class many
{
	int* array;
	int size;

public:

	many();
	many(int size);
	int& operator [] (int i);
	int operator () ();
	void operator ++ (int i);
	many operator + (many& other);
	~many();
};
function ConvertToNumber(input)
{
	rez=0;
	if (isNaN(input) == false )
		{
			rez = parseInt(input)+0;
			if (isNaN(rez) == true )
			{
				rez = 0;
			}
		}
	return rez;
}
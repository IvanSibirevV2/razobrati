function List()
{
	this.a = new Array();
}		
List.prototype.print = function()
{
	text = "Begin:";
	for(i = 0; i < this.a.length; i ++)
	{
		text = text + "\n    List[" + i + "]=" + this.a[ i ];
	}
	text = text + "\nEnd;";
	WScript.echo( text );
}
List.prototype.add = function( input )
{
	this.a[ this.a.length ] = ( input );
}
List.prototype.at = function( input )
{
	if( ( input > - 1) && ( input < this.a.length ) )
	{
		return this.a[ input ];
	}
	else
	{
		text = "Error\n List.prototype.at = function (input)" + "\n Index TypeError" + "\n Input:<" + input + "> bat expect [0;" + ( this.a.length - 1 ) + "]";
		WScript.echo( text );
		return 0;
	}
}
List.prototype.addList = function( inputlist )
{
	if( inputlist instanceof List )
	{
		for( i = 0; i < inputlist.a.length; i ++)
		{
			this.add( inputlist.at( i ) );
		}
	}
}
List.prototype.removeat = function( input )
{
	rez = new List();
	for( i = 0; i < this.a.length; i ++)
	{
		if( parseInt( i ) != parseInt( input ))
		{
			local = this.a[ i ];rez.add( local );
		}
	}
	return rez;
}
List.prototype.Count = function()
{
	return this.a.length;
}
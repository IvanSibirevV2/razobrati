function Point��( input )
{
	rP= new List();
	for( i1 = 1; i1 < input.at(0).Count(); i1 ++)
	{
		rP.add(0);
	}
	for( jP = 1; jP < input.at(0).Count(); jP ++)
	{
		for( iP = 1; iP <input.Count(); iP ++)
		{
			rP.a[ jP - 1 ] = rP.a[ jP - 1 ] + parseFloat( input.at( iP ).at( jP ) );
		}
	}
	for( iP = 0; iP < rP.Count(); iP ++)
	{
		rP.a[iP] = rP.a[iP] / (input.Count() - 1);
	}
	return rP;
}
function Distance��(input1, input2)
{
	i1Distance = Point��(input1);
	i2Distance = Point��(input2);
	rezDistance = 0; 
	if(i1Distance.Count() == i2Distance.Count())
	{
		for(iDistance = 0; iDistance < i1Distance.Count(); iDistance ++)
		{
			qwe = i1Distance.at(iDistance) - i2Distance.at(iDistance);
			rezDistance = rezDistance + qwe * qwe;
		}
	}
	rezDistance = Math.sqrt(rezDistance);
	return rezDistance
}
function DataSightGet(data, x, xx, xxx)
{
	rez = data.at(x).at(xx + 1).at(xxx + 1);
	return rez;
}
function �entroid�lustering(realinput, k, ToBeeNorm)
{
	input = new List();
	input.addList( realinput );
	OutPut�luster = new List();
	for( i = 1; i < input.Count() - 1; i ++)
	{
		NewCluster = new List();
		NewCluster.add(input.at(0));
		NewCluster.add(input.at(i));
		OutPut�luster.add(NewCluster);
	}
	maxList = new List();
	if(ToBeeNorm)
	{
		for( j = 0; j < OutPut�luster.at(0).at(1).Count() - 1; j ++)
		{
			max =- 9999999999;
			for( i = 0; i < OutPut�luster.Count(); i ++)
			{
				qwe = DataSightGet(OutPut�luster, i, 0, j);
				if(qwe > max)
				{
					max = qwe;
				}
			}
			for( i = 0; i < OutPut�luster.Count(); i ++)
			{
				qwe = DataSightGet(OutPut�luster, i, 0, j) / max;
				OutPut�luster.a[i].a[0 + 1].a[j + 1] = qwe;
			}
		maxList.add(max);
		}
	}
	if(OutPut�luster.Count() > 2)
	{
		do
		{
			min = 9999999999999999;
			minI = 0;
			minJ = 0;
			for( i = 0; i < OutPut�luster.Count(); i ++)
			{
				for( j = 0; j < OutPut�luster.Count(); j ++)
				{
					di = Distance��(OutPut�luster.at(i), OutPut�luster.at(j));
					if(i != j)
					{
						if( min >  di)
						{
							min=di;
							minI=i;
							minJ=j;
						}
					}
				}
			}
			NewC = new List();
			NewC.add(OutPut�luster.at(minI).at(0));
			for( i = 1; i < OutPut�luster.at(minI).Count(); i ++)
			{
				NewC.add(OutPut�luster.at(minI).at(i));
			}				
			for( i = 1; i < OutPut�luster.at(minJ).Count(); i ++)
			{
				NewC.add(OutPut�luster.at(minJ).at(i));
			}				
			if(minI > minJ)
			{
				OutPut�luster = OutPut�luster.removeat(minI);
				OutPut�luster = OutPut�luster.removeat(minJ);
			}
			else
			{
				OutPut�luster = OutPut�luster.removeat(minJ);
				OutPut�luster = OutPut�luster.removeat(minI);
			}
			OutPut�luster.add(NewC);
		}
		while (OutPut�luster.Count() > k);
	}if(ToBeeNorm)
	{
		for( i = 0; i < OutPut�luster.Count(); i ++)
		{
			for( j = 0; j < OutPut�luster.a[i].Count(); j ++)
			{
				if( j > 0)
				{
					for( z = 0; z < maxList.Count(); z ++ )
					{
						OutPut�luster.a[i].a[j].a[z + 1] = OutPut�luster.a[i].a[j].a[z + 1] * maxList.a[z];
					}
				}
			}
		}
	}
	return OutPut�luster;
}
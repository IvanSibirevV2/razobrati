function DistanceFCM(input1, input2)
{
	rez = 0;
	if(input1.Count() == input2.Count())
	{
		for(i2 = 1; i2 < input1.Count(); i2 ++)
		{
			qwe = input1.at(i2) - input2.at(i2);
			rez = rez + qwe * qwe;
		}
		rez = Math.sqrt(rez);
	}
	return rez;
}
function FCMClustering(TM, TC, X, E)
{
	Q = 1.5;
	N = TC.Count() - 1;
	for(fdw = 1; fdw < E; fdw ++)
	{
		for(i = 1; i < TC.Count(); i ++)
		{
			for(j = 1; j < TC.a[i].Count(); j ++)
			{
				ch = 0;
				zn = 0; 
				for(w = 1; w < TM.Count(); w ++)
				{
					ch = ch + Math.pow(TM.a[w].a[i], Q) * X.a[w].a[j];
					zn = zn + Math.pow(TM.a[w].a[i], Q);
				}
				TC.a[i].a[j] = ch/zn;
			}
		}
		for(i = 1; i < TM.Count(); i ++)
		{
			flag = false;
			stopset = 0;
			for(j = 1; j < TM.at(i).Count(); j ++)
			{
				if(DistanceFCM(X.a[i], TC.a[j]) == 0)
				{
					flag = true;
					stopset = j;
				}
			}
			if(flag)
			{
				for(j = 1; j < TM.at(i).Count(); j ++)
				{
					if(j == stopset)
					{
						TM.a[i].a[j] = 1;
					}
					if(j != stopset)
					{
						TM.a[i].a[j] = 0;
					}
				}
			}
			else
			{
				for(j = 1; j < TM.at(i).Count(); j ++)
				{
					zn = 0;
					for(k = 1; k < TM.at(i).Count(); k ++)
					{
						zn = zn + 1 / Math.pow(DistanceFCM(X.a[i], TC.a[k]), 1 / (Q - 1));
					}
					TM.a[i].a[j] = (1 / Math.pow(DistanceFCM(X.a[i], TC.a[j]), 1 / (Q - 1))) / zn;
				}
			}
		}
	}
	return TM;
}
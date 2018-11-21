using System;

namespace qqqg
{
public class DMS_ApprovalPersonnel
{
private int _ID;
private string _DocumentInfoID;
private string _DataJosn;
private DateTime _CreateDate;


public int ID
{
get { return _ID; }
set { _ID = value; }
}

public string DocumentInfoID
{
get { return _DocumentInfoID; }
set { _DocumentInfoID = value; }
}

public string DataJosn
{
get { return _DataJosn; }
set { _DataJosn = value; }
}

public DateTime CreateDate
{
get { return _CreateDate; }
set { _CreateDate = value; }
}


}
}

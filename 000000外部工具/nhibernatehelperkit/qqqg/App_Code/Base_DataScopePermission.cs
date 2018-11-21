using System;

namespace qqqg
{
public class Base_DataScopePermission
{
private string _DataScopePermissionId;
private string _Category;
private string _ObjectId;
private string _ModuleId;
private string _ResourceId;
private string _Condition;
private string _ConditionJson;
private string _ScopeType;
private int _SortCode;
private DateTime _CreateDate;
private string _CreateUserId;
private string _CreateUserName;


public string DataScopePermissionId
{
get { return _DataScopePermissionId; }
set { _DataScopePermissionId = value; }
}

public string Category
{
get { return _Category; }
set { _Category = value; }
}

public string ObjectId
{
get { return _ObjectId; }
set { _ObjectId = value; }
}

public string ModuleId
{
get { return _ModuleId; }
set { _ModuleId = value; }
}

public string ResourceId
{
get { return _ResourceId; }
set { _ResourceId = value; }
}

public string Condition
{
get { return _Condition; }
set { _Condition = value; }
}

public string ConditionJson
{
get { return _ConditionJson; }
set { _ConditionJson = value; }
}

public string ScopeType
{
get { return _ScopeType; }
set { _ScopeType = value; }
}

public int SortCode
{
get { return _SortCode; }
set { _SortCode = value; }
}

public DateTime CreateDate
{
get { return _CreateDate; }
set { _CreateDate = value; }
}

public string CreateUserId
{
get { return _CreateUserId; }
set { _CreateUserId = value; }
}

public string CreateUserName
{
get { return _CreateUserName; }
set { _CreateUserName = value; }
}


}
}

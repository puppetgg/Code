﻿using System;
using NetOffice;
using NetOffice.Attributes;
namespace NetOffice.AccessApi.Enums
{
	 /// <summary>
	 /// SupportByVersion Access 10, 11, 12, 14, 15, 16
	 /// </summary>
	 ///<remarks> MSDN Online Documentation: http://msdn.microsoft.com/en-us/en-us/library/office/ff836705.aspx </remarks>
	[SupportByVersion("Access", 10,11,12,14,15,16)]
	[EntityType(EntityType.IsEnum)]
	public enum AcImportXMLOption
	{
		 /// <summary>
		 /// SupportByVersion Access 10, 11, 12, 14, 15, 16
		 /// </summary>
		 /// <remarks>0</remarks>
		 [SupportByVersion("Access", 10,11,12,14,15,16)]
		 acStructureOnly = 0,

		 /// <summary>
		 /// SupportByVersion Access 10, 11, 12, 14, 15, 16
		 /// </summary>
		 /// <remarks>1</remarks>
		 [SupportByVersion("Access", 10,11,12,14,15,16)]
		 acStructureAndData = 1,

		 /// <summary>
		 /// SupportByVersion Access 10, 11, 12, 14, 15, 16
		 /// </summary>
		 /// <remarks>2</remarks>
		 [SupportByVersion("Access", 10,11,12,14,15,16)]
		 acAppendData = 2
	}
}
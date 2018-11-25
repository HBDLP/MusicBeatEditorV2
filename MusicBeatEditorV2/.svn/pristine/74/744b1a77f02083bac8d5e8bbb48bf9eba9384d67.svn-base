using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Excel;
using System.IO;
using System.Data;

public class BeatItemExporter
{

	public static BeatItemProtypes ReadExcel()
	{
		DirectoryInfo pathInfo = new DirectoryInfo(Application.dataPath);
		string excelName = pathInfo.Parent.Parent.FullName + @"/Builder/配置表/BeatItem_障碍物信息.xlsx";
		FileStream stream = File.Open(excelName, FileMode.Open, FileAccess.Read, FileShare.Read);
		IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
		DataSet result = excelReader.AsDataSet();

		System.Data.DataTable wookSheet = result.Tables["Sheet1"];
		int startRow = 5;
		int endRow = wookSheet.Rows.Count;
		int columnCount = wookSheet.Columns.Count;

		List<string> keys = new List<string>();
		for (int index = 0; index < columnCount; index++)
		{
			string keyText = wookSheet.Rows[2][index].ToString();
			if (!keyText.Equals(string.Empty))
			keys.Add(keyText);
		}
		var headerColumns = ExcelHelper.GetColumnsHeader(wookSheet, keys);
		BeatItemProtypes beatItemProtypes = BeatItemProtypes.CreateInstance<BeatItemProtypes>();
		for (int row = startRow; row < endRow; row++)
		{
			string checkStr = ExcelHelper.GetSheetValue(wookSheet, row, headerColumns[keys[0]]);
			if(checkStr.Equals(string.Empty))
				continue;
			BeatItemProtype beatItem = new BeatItemProtype();
			beatItem._type = StrParser.ParseDecInt(ExcelHelper.GetSheetValue(wookSheet, row, headerColumns["Type"]), 0);
			beatItem._obstacleName = StrParser.ParseStr(ExcelHelper.GetSheetValue(wookSheet, row, headerColumns["ObstacleName"]), string.Empty);
			beatItem._rightClickClip = StrParser.ParseDecInt(ExcelHelper.GetSheetValue(wookSheet, row, headerColumns["RightClickClip"]), 0);
			beatItem._keyName = StrParser.ParseStr(ExcelHelper.GetSheetValue(wookSheet, row, headerColumns["KeyName"]), string.Empty);
			beatItem._isHold = StrParser.ParseDecInt(ExcelHelper.GetSheetValue(wookSheet, row, headerColumns["IsHold"]), 0);
			beatItem._isMusicElement = StrParser.ParseDecInt(ExcelHelper.GetSheetValue(wookSheet, row, headerColumns["IsMusicElement"]), 0);
			beatItem._missStopTime = StrParser.ParseFloat(ExcelHelper.GetSheetValue(wookSheet, row, headerColumns["MissStopTime"]), 0f);
			beatItem._missProtectTime = StrParser.ParseFloat(ExcelHelper.GetSheetValue(wookSheet, row, headerColumns["MissProtectTime"]), 0f);
			beatItem._hitHide = StrParser.ParseDecInt(ExcelHelper.GetSheetValue(wookSheet, row, headerColumns["HitHide"]), 0);
			beatItem._missRoleEffect = StrParser.ParseDecInt(ExcelHelper.GetSheetValue(wookSheet, row, headerColumns["MissRoleEffect"]), 0);
			beatItem._rightClickUIPos = StrParser.ParseFloatList(ExcelHelper.GetSheetValue(wookSheet, row, headerColumns["RightClickUIPos"]), 0f);
			beatItem._hitTime = StrParser.ParseFloat(ExcelHelper.GetSheetValue(wookSheet, row, headerColumns["HitTime"]), 0f);
			beatItem._aniName = StrParser.ParseStrList(ExcelHelper.GetSheetValue(wookSheet, row, headerColumns["AniName"]), new string[0]);
			beatItem._aniState = StrParser.ParseDecIntList(ExcelHelper.GetSheetValue(wookSheet, row, headerColumns["AniState"]), 0);
			beatItem._aniTrigger = StrParser.ParseStrList(ExcelHelper.GetSheetValue(wookSheet, row, headerColumns["AniTrigger"]), new string[0]);
			beatItem._holdChangeAniName = StrParser.ParseStrList(ExcelHelper.GetSheetValue(wookSheet, row, headerColumns["HoldChangeAniName"]), new string[0]);
			beatItem._beatFirstStartTime = StrParser.ParseFloat(ExcelHelper.GetSheetValue(wookSheet, row, headerColumns["BeatFirstStartTime"]), 0f);
			beatItem._beatFirstEndTime = StrParser.ParseFloat(ExcelHelper.GetSheetValue(wookSheet, row, headerColumns["BeatFirstEndTime"]), 0f);
			beatItem._beatSecondStartTime = StrParser.ParseFloat(ExcelHelper.GetSheetValue(wookSheet, row, headerColumns["BeatSecondStartTime"]), 0f);
			beatItem._beatSecondEndTime = StrParser.ParseFloat(ExcelHelper.GetSheetValue(wookSheet, row, headerColumns["BeatSecondEndTime"]), 0f);
			beatItem._canFly = StrParser.ParseDecInt(ExcelHelper.GetSheetValue(wookSheet, row, headerColumns["CanFly"]), 0);
			beatItem._speedReduce = StrParser.ParseDecIntList(ExcelHelper.GetSheetValue(wookSheet, row, headerColumns["SpeedReduce"]), 0);
			beatItem._amazingAdd = StrParser.ParseDecInt(ExcelHelper.GetSheetValue(wookSheet, row, headerColumns["AmazingAdd"]), 0);
			beatItem._perfectAdd = StrParser.ParseDecInt(ExcelHelper.GetSheetValue(wookSheet, row, headerColumns["PerfectAdd"]), 0);
			beatItem._greateAdd = StrParser.ParseDecInt(ExcelHelper.GetSheetValue(wookSheet, row, headerColumns["GreateAdd"]), 0);
			beatItem._badAdd = StrParser.ParseDecInt(ExcelHelper.GetSheetValue(wookSheet, row, headerColumns["BadAdd"]), 0);
			beatItem._musicEnergyAdd = StrParser.ParseDecInt(ExcelHelper.GetSheetValue(wookSheet, row, headerColumns["MusicEnergyAdd"]), 0);
			beatItem._amazingAddLuck = StrParser.ParseDecInt(ExcelHelper.GetSheetValue(wookSheet, row, headerColumns["AmazingAddLuck"]), 0);
			beatItem._perfectAddLuck = StrParser.ParseDecInt(ExcelHelper.GetSheetValue(wookSheet, row, headerColumns["PerfectAddLuck"]), 0);
			beatItem._greateAddLuck = StrParser.ParseDecInt(ExcelHelper.GetSheetValue(wookSheet, row, headerColumns["GreateAddLuck"]), 0);
			beatItem._frontAdjustTime = StrParser.ParseFloat(ExcelHelper.GetSheetValue(wookSheet, row, headerColumns["FrontAdjustTime"]), 0f);
			beatItem._backAdjustTime = StrParser.ParseFloat(ExcelHelper.GetSheetValue(wookSheet, row, headerColumns["BackAdjustTime"]), 0f);
			beatItemProtypes.beatItems.Add(beatItem);
		}
		return beatItemProtypes;
	}
}

using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Excel;
using System.IO;
using System.Data;

public class MusicDataExporter
{

	public static MusicDataProtypes ReadExcel()
	{
		DirectoryInfo pathInfo = new DirectoryInfo(Application.dataPath);
		string excelName = pathInfo.Parent.Parent.FullName + @"/Builder/配置表/MusicData_音乐配置表.xlsx";
		FileStream stream = File.Open(excelName, FileMode.Open, FileAccess.Read, FileShare.Read);
		IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
		DataSet result = excelReader.AsDataSet();

		System.Data.DataTable wookSheet = result.Tables["音乐配置表"];
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
		MusicDataProtypes musicDataProtypes = MusicDataProtypes.CreateInstance<MusicDataProtypes>();
		for (int row = startRow; row < endRow; row++)
		{
			string checkStr = ExcelHelper.GetSheetValue(wookSheet, row, headerColumns[keys[0]]);
			if(checkStr.Equals(string.Empty))
				continue;
			MusicDataProtype musicData = new MusicDataProtype();
			musicData._musicName = StrParser.ParseStr(ExcelHelper.GetSheetValue(wookSheet, row, headerColumns["MusicName"]), string.Empty);
			musicData. _prefabName = StrParser.ParseStr(ExcelHelper.GetSheetValue(wookSheet, row, headerColumns["PrefabName"]), string.Empty);
			musicData._loop = StrParser.ParseDecInt(ExcelHelper.GetSheetValue(wookSheet, row, headerColumns["Loop"]), 0);
			musicData._musicVolume = StrParser.ParseFloat(ExcelHelper.GetSheetValue(wookSheet, row, headerColumns["MusicVolume"]), 0f);
			musicData._state = StrParser.ParseDecInt(ExcelHelper.GetSheetValue(wookSheet, row, headerColumns["State"]), 0);
			musicData._id = StrParser.ParseDecInt(ExcelHelper.GetSheetValue(wookSheet, row, headerColumns["ID"]), 0);
			musicData._type = StrParser.ParseDecInt(ExcelHelper.GetSheetValue(wookSheet, row, headerColumns["Type"]), 0);
			musicDataProtypes.musicDatas.Add(musicData);
		}
		return musicDataProtypes;
	}
}

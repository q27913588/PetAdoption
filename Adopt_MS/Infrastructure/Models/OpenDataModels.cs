using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adopt_MS.Infrastructure.Models
{
    public class OpenDataModels
    {

        /// <summary>
        /// 動物的流水編號
        /// </summary>
        public string animal_id { get; set; }

        /// <summary>
        /// 動物的區域編號
        /// </summary>
        public string animal_subid { get; set; }

        /// <summary>
        /// 動物所屬縣市代碼
        /// </summary>
        public int animal_area_pkid { get; set; }

        /// <summary>
        /// 動物所屬收容所代碼
        /// </summary>
        public int animal_shelter_pkid { get; set; }

        /// <summary>
        /// 動物的實際所在地
        /// </summary>
        public string animal_place { get; set; }

        /// <summary>
        /// 動物的類型
        /// </summary>
        public string animal_kind { get; set; }

        /// <summary>
        /// 動物性別
        /// </summary>
        public string animal_sex { get; set; }

        /// <summary>
        /// 動物體型
        /// </summary>
        public string animal_bodytype { get; set; }

        /// <summary>
        /// 動物體型
        /// </summary>
        public string animal_colour { get; set; }

        /// <summary>
        /// 動物年紀
        /// </summary>
        public string animal_age { get; set; }

        /// <summary>
        /// 是否絕育
        /// </summary>
        public string animal_sterilization { get; set; }

        /// <summary>
        /// 是否施打狂犬病疫苗
        /// </summary>
        public string animal_bacterin { get; set; }

        /// <summary>
        /// 動物尋獲地
        /// </summary>
        public string animal_foundplace { get; set; }

        /// <summary>
        /// 動物網頁標題
        /// </summary>
        public string animal_title { get; set; }

        /// <summary>
        /// 動物狀態
        /// </summary>
        public string animal_status { get; set; }

        /// <summary>
        /// 資料備註
        /// </summary>
        public string animal_remark { get; set; }

        /// <summary>
        /// 其他說明
        /// </summary>
        public string animal_caption { get; set; }

        /// <summary>
        /// 開放認養時間(起)
        /// </summary>
        public string animal_opendate { get; set; }

        /// <summary>
        /// 開放認養時間(迄)
        /// </summary>
        public string animal_closeddate { get; set; }

        /// <summary>
        /// 動物資料異動時間
        /// </summary>
        public string animal_update { get; set; }

        /// <summary>
        /// 動物資料建立時間
        /// </summary>
        public string animal_createtime { get; set; }

        /// <summary>
        /// 動物所屬收容所名稱
        /// </summary>
        public string shelter_name { get; set; }

        /// <summary>
        /// 圖片名稱(原始名稱)
        /// </summary>
        public object album_name { get; set; }

        /// <summary>
        /// 圖片名稱
        /// </summary>
        public string album_file { get; set; }


        /// <summary>
        /// 圖片base64編碼
        /// </summary>
        public object album_base64 { get; set; }


        /// <summary>
        /// 異動時間
        /// </summary>
        public object album_update { get; set; }


        /// <summary>
        /// cDate
        /// </summary>
        public DateTime cDate { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string shelter_address { get; set; }


        /// <summary>
        /// 聯絡電話等欄位資訊
        /// </summary>
        public string shelter_tel { get; set; }

    }


}

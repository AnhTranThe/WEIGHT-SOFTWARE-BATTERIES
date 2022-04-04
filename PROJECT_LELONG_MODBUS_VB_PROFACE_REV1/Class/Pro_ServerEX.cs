using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROJECT_LELONG_MODBUS_VB_PROFACE_REV1.Class
{
    public class Pro_ServerEX
    {
          // Class Khai báo tag
        public static string[] tagread(int tagnumber)
        {
            string tagID_1 = "GP40001.#INTERNAL.Sheet1.Group2.Bitadd_Canvao_May1";
            string tagID_2 = "GP40001.#INTERNAL.Sheet1.Group2.Bitadd_Canra_May1";
            string tagID_3 = "GP40001.#INTERNAL.Sheet1.Group2.Bitadd_Canvao_May2";
            string tagID_4 = "GP40001.#INTERNAL.Sheet1.Group2.Bitadd_Canra_May2";


           
         
            string tagID_11 = "GP40001.#INTERNAL.Sheet1.Group1.TL_Acid_May1";
            string tagID_12 = "GP40001.#INTERNAL.Sheet1.Group1.TL_o1_May1";
            string tagID_13 = "GP40001.#INTERNAL.Sheet1.Group1.TL_o2_May1";
            string tagID_14 = "GP40001.#INTERNAL.Sheet1.Group1.TL_o3_May1";
            string tagID_15 = "GP40001.#INTERNAL.Sheet1.Group1.TL_o4_May1";
            string tagID_16 = "GP40001.#INTERNAL.Sheet1.Group1.TL_o5_May1";
            string tagID_17 = "GP40001.#INTERNAL.Sheet1.Group1.TL_o6_May1";
            string tagID_18 = "GP40001.#INTERNAL.Sheet1.Group1.TL_o7_May1";
            string tagID_19 = "GP40001.#INTERNAL.Sheet1.Group1.TL_o8_May1";
            string tagID_20 = "GP40001.#INTERNAL.Sheet1.Group1.TL_o9_May1";
            string tagID_21 = "GP40001.#INTERNAL.Sheet1.Group1.TL_o10_May1";
            
            string tagID_22 = "GP40001.#INTERNAL.Sheet1.Group1.TL_Acid_May2";
            string tagID_23 = "GP40001.#INTERNAL.Sheet1.Group1.TL_o1_May2";
            string tagID_24 = "GP40001.#INTERNAL.Sheet1.Group1.TL_o2_May2";
            string tagID_25 = "GP40001.#INTERNAL.Sheet1.Group1.TL_o3_May2";
            string tagID_26 = "GP40001.#INTERNAL.Sheet1.Group1.TL_o4_May2";
            string tagID_27 = "GP40001.#INTERNAL.Sheet1.Group1.TL_o5_May2";
            string tagID_28 = "GP40001.#INTERNAL.Sheet1.Group1.TL_o6_May2";
            string tagID_29 = "GP40001.#INTERNAL.Sheet1.Group1.TL_o7_May2";
            string tagID_30 = "GP40001.#INTERNAL.Sheet1.Group1.TL_o8_May2";
            string tagID_31 = "GP40001.#INTERNAL.Sheet1.Group1.TL_o9_May2";
            string tagID_32 = "GP40001.#INTERNAL.Sheet1.Group1.TL_o10_May2";



            string tagID_33 = "GP40001.#INTERNAL.Sheet1.Group2.Bitadd_baoloi";
            string tagID_34 = "GP40001.#INTERNAL.Sheet1.Group2.Bit_add_bc_EXCEL_ca1";
            string tagID_35 = "GP40001.#INTERNAL.Sheet1.Group2.Bit_add_bc_EXCEL_ca2";



           
            
            string tagID_36 = "GP40001.#INTERNAL.Sheet1.Group1.TL_LucDau_May1";
            string tagID_37 = "GP40001.#INTERNAL.Sheet1.Group1.TL_LucSau_May1";
           
         
            string tagID_38 = "GP40001.#INTERNAL.Sheet1.Group1.SL_PLVao_May1";
            string tagID_39 = "GP40001.#INTERNAL.Sheet1.Group1.SL_PLRa_May1";
            string tagID_40 = "GP40001.#INTERNAL.Sheet1.Group1.TT_PLVao_May1";
            string tagID_41 = "GP40001.#INTERNAL.Sheet1.Group1.TT_PLRa_May1";

            string tagID_42 = "GP40001.#INTERNAL.Sheet1.Group1.TL_LucDau_May2";
            string tagID_43 = "GP40001.#INTERNAL.Sheet1.Group1.TL_LucSau_May2";
           
            
            
            string tagID_44 = "GP40001.#INTERNAL.Sheet1.Group1.SL_PLVao_May2";
            string tagID_45 = "GP40001.#INTERNAL.Sheet1.Group1.SL_PLRa_May2";
            string tagID_46 = "GP40001.#INTERNAL.Sheet1.Group1.TT_PLVao_May2";
            string tagID_47 = "GP40001.#INTERNAL.Sheet1.Group1.TT_PLRa_May2";

            string tagID_48 = "GP40001.#INTERNAL.Sheet1.Group2.SoCa";

          



            string tagID_49 = "GP40001.#INTERNAL.Sheet1.Group3.Ca1_SPdacan";
            string tagID_50 = "GP40001.#INTERNAL.Sheet1.Group3.Ca1_SPdat";
            string tagID_51 = "GP40001.#INTERNAL.Sheet1.Group3.Ca1_SPthap";
            string tagID_52 = "GP40001.#INTERNAL.Sheet1.Group3.Ca1_SPcao";

            string tagID_53 = "GP40001.#INTERNAL.Sheet1.Group3.Ca2_SPdacan";
            string tagID_54 = "GP40001.#INTERNAL.Sheet1.Group3.Ca2_SPdat";
            string tagID_55 = "GP40001.#INTERNAL.Sheet1.Group3.Ca2_SPthap";
            string tagID_56 = "GP40001.#INTERNAL.Sheet1.Group3.Ca2_SPcao";

            string tagID_57 = "GP40001.#INTERNAL.Sheet1.Group2.Ngay";
            string tagID_58 = "GP40001.#INTERNAL.Sheet1.Group2.Thang";
            string tagID_59 = "GP40001.#INTERNAL.Sheet1.Group2.Nam";
            string tagID_60 = "GP40001.#INTERNAL.Sheet1.Group2.Gio";
            string tagID_61 = "GP40001.#INTERNAL.Sheet1.Group2.Phut";
            string tagID_62 = "GP40001.#INTERNAL.Sheet1.Group2.Giay";
        
            string tagID_63 = "GP40001.#INTERNAL.Sheet1.Group1.MaSoLoHang";
            string tagID_64 = "GP40001.#INTERNAL.Sheet1.Group1.QuyCach";
            string tagID_65 = "GP40001.#INTERNAL.Sheet1.Group1.NguoiThaoTac";
            string tagID_66 = "GP40001.#INTERNAL.Sheet1.Group1.TLBinhChuaCoAxit";
            string tagID_67 = "GP40001.#INTERNAL.Sheet1.Group1.TLAxitTC";

            string tagID_68 = "GP40001.#INTERNAL.Sheet1.Group1.DSD_BinhVao";
            string tagID_69 = "GP40001.#INTERNAL.Sheet1.Group1.DST_BinhVao";
            string tagID_70 = "GP40001.#INTERNAL.Sheet1.Group1.DSH_BinhVao";
            string tagID_71 = "GP40001.#INTERNAL.Sheet1.Group1.DSL_BinhVao";
            string tagID_72 = "GP40001.#INTERNAL.Sheet1.Group1.DSD_BinhRa";
            string tagID_73 = "GP40001.#INTERNAL.Sheet1.Group1.DST_BinhRa";
            string tagID_74 = "GP40001.#INTERNAL.Sheet1.Group1.DSH_BinhRa";
            string tagID_75 = "GP40001.#INTERNAL.Sheet1.Group1.DSL_BinhRa";

            //////////////////////////////////////////////////////////
         

            string tagID_76 = "GP40001.#INTERNAL.Sheet1.Group2.TB_CanVao_May1_Ca1_Test";
            string tagID_77 = "GP40001.#INTERNAL.Sheet1.Group2.TB_CanVao_May1_Ca2_Test";
            string tagID_78 = "GP40001.#INTERNAL.Sheet1.Group2.TB_CanRa_May1_Ca1_Test";
            string tagID_79 = "GP40001.#INTERNAL.Sheet1.Group2.TB_CanRa_May1_Ca2_Test";

            string tagID_80 = "GP40001.#INTERNAL.Sheet1.Group2.TB_CanVao_May2_Ca1_Test";
            string tagID_81 = "GP40001.#INTERNAL.Sheet1.Group2.TB_CanVao_May2_Ca2_Test";
            string tagID_82 = "GP40001.#INTERNAL.Sheet1.Group2.TB_CanRa_May2_Ca1_Test";
            string tagID_83 = "GP40001.#INTERNAL.Sheet1.Group2.TB_CanRa_May2_Ca2_Test";

            string tagID_84 = "GP40001.#INTERNAL.Sheet1.Group2.GT_CanVao_May1_Test";
         
            string tagID_85 = "GP40001.#INTERNAL.Sheet1.Group2.GT_CanRa_May1_Test";

            string tagID_86 = "GP40001.#INTERNAL.Sheet1.Group2.GT_CanVao_May2_Test";

            string tagID_87 = "GP40001.#INTERNAL.Sheet1.Group2.GT_CanRa_May2_Test";

            /////////////////////////////////////////////////////////////////////


          //  string tagID_5 = "GP40001.PLC1.Sheet6.TB_CanVao_May1";
          //  string tagID_8 = "GP40001.PLC1.Sheet6.TB_CanVao_May2";
          
            

            string tagID_6 = "GP40001.#INTERNAL.Sheet1.Group3.TB_CanRa_May1_Ca1";
            string tagID_7 = "GP40001.#INTERNAL.Sheet1.Group3.TB_CanRa_May1_Ca2";
            string tagID_9 = "GP40001.#INTERNAL.Sheet1.Group3.TB_CanRa_May2_Ca1";
            string tagID_10 = "GP40001.#INTERNAL.Sheet1.Group3.TB_CanRa_May2_Ca2";

            string tagID_88 = "GP40001.#INTERNAL.Sheet1.Group3.TB_CanVao_May1_Ca1";
            string tagID_89 = "GP40001.#INTERNAL.Sheet1.Group3.TB_CanVao_May1_Ca2";
            string tagID_90 = "GP40001.#INTERNAL.Sheet1.Group3.TB_CanVao_May2_Ca1";
            string tagID_91 = "GP40001.#INTERNAL.Sheet1.Group3.TB_CanVao_May2_Ca2";

            

            string tagID_92 = "GP40001.#INTERNAL.Sheet1.Group2.Bit_add_ca1";
            string tagID_93 = "GP40001.#INTERNAL.Sheet1.Group2.Bit_add_ca2";


            string tagID_94 = "GP40001.#INTERNAL.Sheet1.Group2.Bit_add_xoa_cpk1";
            string tagID_95 = "GP40001.#INTERNAL.Sheet1.Group2.Bit_add_xoa_cpk2";



            string tagID_96 = "GP40001.#INTERNAL.Sheet1.Group2.GT_Binhloi_May1_1";
            string tagID_97 = "GP40001.#INTERNAL.Sheet1.Group2.GT_Binhloi_May1_2";
            string tagID_98 = "GP40001.#INTERNAL.Sheet1.Group2.GT_Binhloi_May1_3";
            string tagID_99 = "GP40001.#INTERNAL.Sheet1.Group2.GT_Binhloi_May1_4";
            string tagID_100 = "GP40001.#INTERNAL.Sheet1.Group2.GT_Binhloi_May1_5";


            string tagID_101 = "GP40001.#INTERNAL.Sheet1.Group2.GT_Binhloi_May2_1";
            string tagID_102 = "GP40001.#INTERNAL.Sheet1.Group2.GT_Binhloi_May2_2";
            string tagID_103 = "GP40001.#INTERNAL.Sheet1.Group2.GT_Binhloi_May2_3";
            string tagID_104 = "GP40001.#INTERNAL.Sheet1.Group2.GT_Binhloi_May2_4";
            string tagID_105 = "GP40001.#INTERNAL.Sheet1.Group2.GT_Binhloi_May2_5";

            string tagID_106 = "GP40001.#INTERNAL.Sheet1.Group2.GT_Tongbinhloi_May1";
            string tagID_107 = "GP40001.#INTERNAL.Sheet1.Group2.GT_Tongbinhloi_May2";
            string tagID_108 = "GP40001.#INTERNAL.Sheet1.Group2.GT_Tongbinhloi";
            string tagID_109 = "GP40001.#INTERNAL.Sheet1.Group2.Bit_Thap_Phan";




            // thay thế gt cân vào, gT cân ra của máy 1 và máy 2
            // thay thế giá trị tổng bình cân vào, cân ra ca 1 và ca 2 máy 1 và máy 2 
            // thay thế số ca 



            string[] tags;

            tags = new string[tagnumber];
            tags.SetValue(tagID_1, 1);
            tags.SetValue(tagID_2, 2);
            tags.SetValue(tagID_3, 3);
            tags.SetValue(tagID_4, 4);
       
            tags.SetValue(tagID_6, 6);
            tags.SetValue(tagID_7, 7);
          
            tags.SetValue(tagID_9, 9);
            tags.SetValue(tagID_10, 10);
            tags.SetValue(tagID_11, 11);
            tags.SetValue(tagID_12, 12);
            tags.SetValue(tagID_13, 13);
            tags.SetValue(tagID_14, 14);
            tags.SetValue(tagID_15, 15);
            tags.SetValue(tagID_16, 16);
            tags.SetValue(tagID_17, 17);
            tags.SetValue(tagID_18, 18);
            tags.SetValue(tagID_19, 19);
            tags.SetValue(tagID_20, 20);
            tags.SetValue(tagID_21, 21);
            tags.SetValue(tagID_22, 22);
            tags.SetValue(tagID_23, 23);
            tags.SetValue(tagID_24, 24);
            tags.SetValue(tagID_25, 25);
            tags.SetValue(tagID_26, 26);
            tags.SetValue(tagID_27, 27);
            tags.SetValue(tagID_28, 28);
            tags.SetValue(tagID_29, 29);
            tags.SetValue(tagID_30, 30);
            tags.SetValue(tagID_31, 31);
            tags.SetValue(tagID_32, 32);
            tags.SetValue(tagID_33, 33);
            tags.SetValue(tagID_34, 34);
            tags.SetValue(tagID_35, 35);
            tags.SetValue(tagID_36, 36);
            tags.SetValue(tagID_37, 37);
            tags.SetValue(tagID_38, 38);
            tags.SetValue(tagID_39, 39);
            tags.SetValue(tagID_40, 40);
            tags.SetValue(tagID_41, 41);
            tags.SetValue(tagID_42, 42);
            tags.SetValue(tagID_43, 43);
            tags.SetValue(tagID_44, 44);
            tags.SetValue(tagID_45, 45);
            tags.SetValue(tagID_46, 46);
            tags.SetValue(tagID_47, 47);
            tags.SetValue(tagID_48, 48);
            tags.SetValue(tagID_49, 49);
            tags.SetValue(tagID_50, 50);
            tags.SetValue(tagID_51, 51);
            tags.SetValue(tagID_52, 52);
            tags.SetValue(tagID_53, 53);
            tags.SetValue(tagID_54, 54);
            tags.SetValue(tagID_55, 55);
            tags.SetValue(tagID_56, 56);
            tags.SetValue(tagID_57, 57);
            tags.SetValue(tagID_58, 58);
            tags.SetValue(tagID_59, 59);
            tags.SetValue(tagID_60, 60);
            tags.SetValue(tagID_61, 61);
            tags.SetValue(tagID_62, 62);
            tags.SetValue(tagID_63, 63);
            tags.SetValue(tagID_64, 64);
            tags.SetValue(tagID_65, 65);
            tags.SetValue(tagID_66, 66);
            tags.SetValue(tagID_67, 67);
            tags.SetValue(tagID_68, 68);
            tags.SetValue(tagID_69, 69);
            tags.SetValue(tagID_70, 70);
            tags.SetValue(tagID_71, 71);
            tags.SetValue(tagID_72, 72);
            tags.SetValue(tagID_73, 73);
            tags.SetValue(tagID_74, 74);
            tags.SetValue(tagID_75, 75);

            
            tags.SetValue(tagID_76, 76);
            tags.SetValue(tagID_77, 77);
            tags.SetValue(tagID_78, 78);
            tags.SetValue(tagID_79, 79);
            tags.SetValue(tagID_80, 80);
            tags.SetValue(tagID_81, 81);
            tags.SetValue(tagID_82, 82);
            tags.SetValue(tagID_83, 83);
            tags.SetValue(tagID_84, 84);
            tags.SetValue(tagID_85, 85);
            tags.SetValue(tagID_86, 86);
            tags.SetValue(tagID_87, 87);
            tags.SetValue(tagID_88, 88);
            tags.SetValue(tagID_89, 89);
            tags.SetValue(tagID_90, 90);
            tags.SetValue(tagID_91, 91);
            tags.SetValue(tagID_92, 92);
            tags.SetValue(tagID_93, 93);
            tags.SetValue(tagID_94, 94);
            tags.SetValue(tagID_95, 95);

            tags.SetValue(tagID_96, 96);
            tags.SetValue(tagID_97, 97);
            tags.SetValue(tagID_98, 98);
            tags.SetValue(tagID_99, 99);
            tags.SetValue(tagID_100, 100);
            tags.SetValue(tagID_101, 101);
            tags.SetValue(tagID_102, 102);
            tags.SetValue(tagID_103, 103);
            tags.SetValue(tagID_104, 104);
            tags.SetValue(tagID_105, 105);
            tags.SetValue(tagID_106, 106);
            tags.SetValue(tagID_107, 107);
            tags.SetValue(tagID_108, 108);
            tags.SetValue(tagID_109, 109);

            return tags;
            

          
        
}
        // Class tạo array đọc ID tags - mặc định không đổi
        public static Int32[] tagID(int tagnumber)
        {
            Int32[] cltarr;
            cltarr = new Int32[tagnumber];
            for (int i = 1; i < tagnumber; i++) {
                cltarr.SetValue(i, i);
            }
            return cltarr;
        }
    
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autotester
{
    static class RegexHelper 
    {
        public static string Reg = @"^[A-Za-z0-9áéiíoóöőuúüűÁÉIÍOÓÖŐUÚÜŰ_\-\.\+][A-Za-z0-9áéiíoóöőuúüűÁÉIÍOÓÖŐUÚÜŰ_\-\.\+\s*]{0,199}$"; //az első része, hogy bármilyen megengedett karakter lehet, kivéve space-et, később pedig szóköz is lehet.
        public static string RegHiba = "Név: \n Legalább 1, legfeljebb 200 karakter hosszú kifejezést vár,ékezetes betűk és [ _ - . +] karakterek megengedettek, a szöveg nem kezdődhet szóközzel";
        public static string ATG_TC_ID_FROM = "Teszteset ID-tól: \n Nem nullával kezdődő négyjegyű számot vár";
        public static string ATG_TC_ID_TO = "Teszteset ID-ig: \n Nem nullával kezdődő négyjegyű számot vár";
        public static string ID_LENGHT = "Hossz megadása: \n Nem nullával kezdődő pozitív egész számot vár, melynek maximum értéke 10 lehet";
        public static string ATG_RUN_ID = "Futáscsoport: \n Nem nullával kezdődő legfeljebb háromjegyű számot vár";
        public static string ATG_TESTCASE_NAME = "Teszteset neve: \n Legalább 1, legfeljebb 25 karakter hosszú kifejezést vár,ékezetes betűk és [ _ - . +] karakterek megengedettek";
        public static string ATG_NAME = "Név: \n Legalább 1, legfeljebb 200 karakter hosszú kifejezést vár,ékezetes betűk és [ _ - . +] karakterek megengedettek";
        public static string ATG_TEST_TYPE = "Teszteset típus: \n Legalább 1, legfeljebb 50 karakter hosszú kifejezést vár, speciális karakterek NEM megengedettek";
        public static string letezik = "Már létezik ilyen nevű teszteset";
        public static string haromjegyu = "^[1-9][0-9]{3}$";
        public static string tizig = "^[1-9]$|^[1][0]$";
        public static string negyjegyu = @"^[1-9]$|^[1-9][0-9]$|^[1-9][0-9][0-9]$";
        public static string huszonot = @"^[A-Za-z0-9áéiíoóöőuúüűÁÉIÍOÓÖŐUÚÜŰ_\-\.\+\s*]{1,25}$";
        public static string ketszaz = @"^[A-Za-z0-9áéiíoóöőuúüűÁÉIÍOÓÖŐUÚÜŰ_\(\)\:\-\.\+\s*]{1,200}$";
        public static string otven = @"^[A-Za-z0-9\s*]{0,50}$";
    }

    static class SqlLekerdezesek
    {
        public static string idTartomany = "select ATG_TC_ID_FROM, ATG_TC_ID_TO from pch.AUTOTESTER_GROUPS";
        public static string idAndTestcase = "select ATG_TESTCASE_NAME, ATG_ID from pch.AUTOTESTER_GROUPS where atg_testcase_name is not null order by ATG_TESTCASE_NAME";
        public static string updateClob = "update pch.autotester_tests set atr_sql = :clob where atr_id = ";
    }

    static class CsereModul
    {
        public static string mt_id = "    <Variable Name=\"MT_ID\" Value=\"' || v_id || '\"/>";
        public static string cu_name = "    <Variable Name=\"CU_NAME\" Value=\"''PCH Autotester '' || ''' || v_id || '''\"/>";
        public static string building = "    <Variable Name=\"BUILDING\" Value=\"''BD'' || to_char(sysdate, ''YYYYMMDD'') || ''' || v_id || '''\"/>";
        public static string service_point_id = "    <Variable Name=\"SERVICE_POINT_ID\" Value=\"to_char(sysdate, ''YYYYMMDD'') || ''' || v_id || '''\"/>";
        public static string premise_id = "    <Variable Name=\"PREMISE_ID\" Value=\"''PRE'' || to_char(sysdate, ''YYYYMMDD'') || ''' || v_id || '''\"/>";
        public static string cu_firstname = "    <Variable Name=\"CUFIRSTNAME\" Value=\"Tester\"/>";
        public static string cu_lastname = "    <Variable Name=\"CULASTNAME\" Value=\"Tester\"/>";
        public static string eleje = @"declare
   v_id number:= :v_id;
   v_key_id number;
   v_xml_config clob := '<?xml version=""1.0"" encoding=""UTF-8""?>
  <TestCase DisableTestCenterbeforeOrder="""" NoWFMSEQType="""" ZTPCloseType="""" CrmSys="""" FlowType="""" EnableNMSSimulation ="""" FreeDevicesOnCircuit="""">
    ";
        public static string vege = @"begin
:v_key_id := sim.flow_handler.controller_bwf_call(v_xml_config);
end;";

        public static string BorzEleje = @"declare
v_id number := :v_id;
v_key_id number;
        v_xml_config clob := '<?xml version=""1.0"" encoding=""UTF-8""?>
<TestCase CrmSys = ""BORZ"" > 
";

    }
    static class Sugo
    {
        public static string noSpecList = "SpecList nélküli autotester indító eleje";
        public static string SpecList = "SpecList autotester indító eleje (A SpecListen belül a sorok csak irányadók)";
        public static string atVege = "autotester indító Lezárása";
        public static string tapteruletek = "Tápterületek listája";
        public static string fejlesztette = "Fejlesztette: Riedly Dénes, 2017-2018";
    }

    static class Egyeb
    {
        public static string sfdFilter = "Normal text file (*.txt)|*.txt|Comma-separated values file (*.csv)|*.csv|Structured Query Language file (*.sql)|*.sql|All files (*.*)|*.*";
        public static string ofdFilter = "txt files (*.txt)|*.txt|CSV files (*.csv)|*.csv|Structured Query Language file (*.sql)|*.sql|All files (*.*)|*.*";
    }
}

using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Dynamic;
using System.Reflection;

/*
    Bước 1: Mở Visual Studio.
    Bước 2: Chọn menu Tools > NuGet Package Manager > Package Manager Console.
    Bước 3: Thêm thư viện thì chạy câu lệnh sau đây

    Install-Package Oracle.ManagedDataAccess

    
    chạy thêm lệnh
    Install-Package System.Configuration.ConfigurationManager


    cài thư viện để truy cập oracle
    với dự án phiên bản net 8.0
    NuGet\Install-Package Oracle.ManagedDataAccess.Core -Version 23.6.1

    trước khi cài ManagedDataAccess.Core
    vui lòng kiểm tra target framework
    phải chọn ManagedDataAccess.Core cho phù hợp với phiên bản net đang sử dụng
*/

namespace MyApp
{
    public class QueryData
    {
        public static string OUT_CURSOR = "OUT_CURSOR";
        public static string OUT_NUMBER = "OUT_NUMBER";
        public static string OUT_STRING = "OUT_STRING";
        public static string OUT_DATE = "OUT_DATE";
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                // có tài khoản của công ty
                // tenant nghĩa là người thuê nhà
                bool? haveUserTenant = true;

                // trạng thái tài khoản có phải Admin không
                bool isAdmin = true;

                // cấu hình bộ lọc
                CustomizeFilter filter = new CustomizeFilter() { Code = null, Name = null, OrgName = null, PositionName = null };

                string sqlText = "PKG_PAYROLL.LIST_PAYROLL_SUM";

                string connectionString = "Persist Security Info=True; Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=103.145.63.46)(PORT=1522))(CONNECT_DATA=(SERVICE_NAME=dbgohr)));User ID=TENANTDB1_KL;Password=hrm;Connection Timeout=5";

                string strPosOut = "";

                var obj = new
                {
                    P_IS_ADMIN = isAdmin == true ? 1 : 0,
                    P_ORG_ID = 3201,                                    // TẬP ĐOÀN KIM LONG, bảng HU_ORGANIZATION
                    P_PERIOD_ID = 3942,                                 // tháng 9 năm 2024, bảng AT_SALARY_PERIOD
                    P_IS_QUIT = 0,
                    P_SALARY_TYPE_ID = 1662,                            // Bảng lương Hồng Vận, bảng HU_SALARY_TYPE
                    P_CODE = filter.Code,
                    P_NAME = filter.Name,
                    P_ORG_NAME = filter.OrgName,
                    P_POS_NAME = filter.PositionName,
                    P_PAGE_NO = 1,
                    P_PAGE_SIZE = 20,
                    P_CUR = QueryData.OUT_CURSOR,
                    P_CUR_PAGE = QueryData.OUT_CURSOR
                };

                // tạo đối tượng Oracle Connection
                OracleConnection conn = new OracleConnection(connectionString);

                // tạo đối tượng Oracle Command
                OracleCommand cmd = new OracleCommand(sqlText, conn);

                // mở kết nối tới cơ sở dữ liệu
                conn.Open();

                // chọn chế độ thực thi Command
                // là thủ tục StoredProcedure
                // nếu chỉ là dòng lệnh SQL thì dùng CommandType.Text
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                // thêm tham số
                if (haveUserTenant != null && haveUserTenant == true)
                {
                    // khởi tạo tenantId và userId
                    OracleParameter tenantId = new OracleParameter();
                    tenantId.ParameterName = "P_TENANT_ID";
                    tenantId.DbType = DbType.Int64;
                    tenantId.Value = 1890;                                  // công ty Kim Long thì TENANT_ID = 1890

                    OracleParameter userId = new OracleParameter();
                    userId.ParameterName = "P_USER_ID";
                    userId.DbType = DbType.String;
                    if (isAdmin == true) userId.Value = "ADMIN";
                    else userId.Value = "them_tai_khoan_vao_day";

                    // thêm tenantId và userId vào thuộc tính cmd.Parameters
                    cmd.Parameters.Add(tenantId);
                    cmd.Parameters.Add(userId);
                }

                // Add parameter
                var p = obj.GetType();
                foreach (PropertyInfo info in p.GetProperties())
                {
                    bool bOut = false;
                    var para = GetParameter(info.Name, info.GetValue(obj, null), ref bOut);
                    if (para != null)
                    {
                        if (bOut) strPosOut += info.Name + ";";
                        cmd.Parameters.Add(para);
                    }
                }

                List<List<ExpandoObject>> res = new List<List<ExpandoObject>>();

                using (var reader = cmd.ExecuteReader())
                {
                    do
                    {
                        List<ExpandoObject> lst = new List<ExpandoObject>();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var expandoObject = new ExpandoObject() as IDictionary<string, object>;
                                for (var i = 0; i < reader.FieldCount; i++)
                                    expandoObject.Add(reader.GetName(i), reader[i]);
                                lst.Add(expandoObject as ExpandoObject);
                            };
                        }

                        res.Add(lst);

                    }
                    while (reader.NextResult());
                }

                cmd.Dispose();

                // đóng kết nối và giải phóng tài nguyên
                conn.Close();
                conn.Dispose();


                // cái quan tâm chính là res
                var expectResult = res;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static Dictionary<string, int> arrOutType = new Dictionary<string, int>()
        {
            { "OUT_CURSOR", 0 },
            { "OUT_NUMBER", 1 },
            { "OUT_STRING", 2 },
            { "OUT_DATE", 3 }
        };

        public static OracleParameter GetParameter(string sKey, Object sValue, ref bool bOut)
        {
            OracleParameter para = new OracleParameter();
            para.ParameterName = sKey;

            bool condition1 = sValue == null;
            bool condition2 = sValue != null & (sValue != DBNull.Value);
            bool condition3 = !arrOutType.ContainsKey(sValue != null ? sValue.ToString() : "");

            if (condition1 || (condition2 && condition3))
            {
                if (sValue != null)
                {
                    // Kiểm tra type để gán thuộc tính tương ứng
                    switch (sValue.GetType())
                    {
                        case var @case when @case == typeof(bool):
                            {
                                para.DbType = DbType.Int16;
                                if (bool.Parse(sValue.ToString()))
                                    para.Value = -1;
                                else
                                    para.Value = 0;
                                break;
                            }

                        case var case1 when case1 == typeof(DateTime):
                            {
                                para.DbType = DbType.Date;
                                para.Value = sValue;
                                break;
                            }
                        case var case3 when case3 == typeof(double):
                            {
                                para.DbType = DbType.Double;
                                para.Value = sValue;
                                break;
                            }

                        case var case4 when case4 == typeof(decimal):
                            {
                                para.DbType = DbType.Decimal;
                                para.Value = sValue;
                                break;
                            }

                        case var case5 when case5 == typeof(int):
                            {
                                para.DbType = DbType.Int64;
                                para.Value = sValue;
                                break;
                            }

                        case var case6 when case6 == typeof(string):
                            {
                                para.DbType = DbType.String;
                                para.Value = sValue;
                                break;
                            }

                        case var case7 when case7 == typeof(byte[]):
                            {
                                para.DbType = DbType.Binary;
                                if (sValue == DBNull.Value)
                                    para.Size = 8;
                                para.Value = sValue;
                                break;
                            }
                        case var case8 when case8 == typeof(Int64):
                            {
                                para.DbType = DbType.Int64;
                                para.Value = sValue;
                                break;
                            }
                    }
                }
            }
            else if (sValue == DBNull.Value)
            {
                para.Size = 8;
                para.Value = sValue;
            }
            else
            {
                para.Direction = ParameterDirection.Output;
                switch (arrOutType[sValue.ToString()])
                {
                    case 0:
                        {
                            para.OracleDbType = OracleDbType.RefCursor;
                            break;
                        }

                    case 1:
                        {
                            bOut = true;
                            para.OracleDbType = OracleDbType.Decimal;
                            break;
                        }

                    case 2:
                        {
                            bOut = true;
                            para.OracleDbType = OracleDbType.NVarchar2;
                            para.Size = 255;
                            break;
                        }

                    case 3:
                        {
                            bOut = true;
                            para.OracleDbType = OracleDbType.Date;
                            break;
                        }
                }
            }

            return para;
        }
    }

    public class CustomizeFilter
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? OrgName { get; set; }
        public string? PositionName { get; set; }
    }
}
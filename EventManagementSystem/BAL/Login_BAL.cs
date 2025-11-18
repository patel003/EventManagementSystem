using EventManagementSystem.Models;
using EventManagementSystem.Models.Login;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementSystem.BAL
{
    public class Login_BAL
    {
        private readonly DAL.Login_DAL _loginDAL;
        public Login_BAL()
        {
                _loginDAL = new DAL.Login_DAL();
        }

        CommonResponse<UserDTO> Response = new CommonResponse<UserDTO>();
         
        public  CommonResponse<UserDTO> login(LoginModel lm)
        {

            try
            {
                if (string.IsNullOrWhiteSpace(lm.Email))
                {
                    Response.Code = 0;
                    Response.Status = false;
                    Response.Message = "Email is required";
                    return Response;

                }
                else if (string.IsNullOrWhiteSpace(lm.Pass))
                {
                    Response.Code = 0;
                    Response.Status = false;
                    Response.Message = "Pass is required";
                    return Response;
                }
                else
                {

                    var dt = _loginDAL.Login(lm);
                    if (dt.Rows.Count > 0)
                    {

                        string MSG = dt.Rows[0]["MSG"].ToString();
                        if (MSG == "Login")
                        {
                            Response.Code = 1;
                            Response.Status = true;
                            Response.Message = "Login Successful.";
                            Response.Data = new List<UserDTO>
                            {

                                 new UserDTO
                                 {
                                       ID = Convert.ToInt32(dt.Rows[0]["ID"]),
                                       FULL_NAME = dt.Rows[0]["FULL_NAME"].ToString(),
                                       ROLE_NAME = dt.Rows[0]["ROLE_NAME"].ToString(),
                                       EMAIL = dt.Rows[0]["EMAIL"].ToString(),
                                       PHONE_NO = dt.Rows[0]["PHONE_NO"].ToString(),
                                       ADDRESS = dt.Rows[0]["ADDRESS"].ToString(),
                                       ROLE_ID = Convert.ToInt32(dt.Rows[0]["ROLE_Id"]),
                                       CREATED_DATE = Convert.ToDateTime(dt.Rows[0]["CREATED_DATE"]),
                                       ISACTIVE= Convert.ToBoolean(dt.Rows[0]["ISACTIVE"]),
                                       PASS = dt.Rows[0]["PASS"].ToString()
                                 }


                            };
                            return Response;
                        }
                        else
                        {
                            Response.Code = 0;
                            Response.Status = false;
                            Response.Message = MSG;
                            return Response;
                        }
                    }
                    else
                    {
                        Response.Code = 0;
                        Response.Status = false;
                        Response.Message = "Invalide Email or pass";
                        return Response;
                    }
                }
            }

            catch(Exception ex)
            {
                Response.Code = 0;
                Response.Status = false;
                Response.Message = $"An error occurred :{ex.Message}";
                return Response;

            }
      
             
        }

        internal object Login(LoginModel model)
        {
            throw new NotImplementedException();
        }



    }
}

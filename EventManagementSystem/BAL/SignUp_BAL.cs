using EventManagementSystem.DAL;
using EventManagementSystem.Models;
using EventManagementSystem.Models.Login;

namespace EventManagementSystem.BAL
{
    public class SignUp_BAL
    {

        private readonly DAL.SignUp_DAL _SignUpDAL;
        public SignUp_BAL()
        {
            _SignUpDAL = new DAL.SignUp_DAL();
        }

        CommonResponse<UserDTO> Response = new Models.CommonResponse<UserDTO>();

        public CommonResponse<UserDTO> SignUp(SignUpData sr)
        {

            try
            {
                if (string.IsNullOrWhiteSpace(sr.EMAIL))
                {
                    Response.Code = 0;
                    Response.Status = false;
                    Response.Message = "Email is required";
                    return Response;

                }
                else if (string.IsNullOrWhiteSpace(sr.PASS))
                {
                    Response.Code = 0;
                    Response.Status = false;
                    Response.Message = "Pass is required";
                    return Response;
                }
                else
                {

                    var dt = _SignUpDAL.SignUp(sr);
                    if (dt.Rows.Count > 0)
                    {

                        string MSG = dt.Rows[0]["MSG"].ToString();
                        if (MSG == "SignUp Successfull")
                        {
                            Response.Code = 1;
                            Response.Status = true;
                            Response.Message = "SignUp Successfull";
                            Response.Data = null;
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

            catch (Exception ex)
            {
                Response.Code = 0;
                Response.Status = false;
                Response.Message = $"An error occurred :{ex.Message}";
                return Response;

            }


        }
    }
}

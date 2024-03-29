﻿using System;
using System.Diagnostics;
using System.Threading.Tasks;
using firstapp.ENUMS;
using firstapp.Models;

namespace firstapp
{
    public class ServerConnect
    {
        public IApiCognito AuthApi => new ApiCognito();

        public ServerConnect()
        {
        }

        async public Task<ServerReplyStatus> Connect(UserAuthInfoObject _connectInfo)
        {

            var responseCognito = new CognitoContext();
            var funcReply = ServerReplyStatus.Unknown;
            string user;
            string pass;

            switch (_connectInfo.AuthType)
            {
                case AuthType.SignUp:
                    user = _connectInfo.Email.Trim().ToLower();
                    pass = _connectInfo.Password.Trim();
                    responseCognito = await AuthApi.SignUp(user, pass);

                    switch (responseCognito.Result)
                    {
                        case CognitoResult.SignupOk:
                            Debug.WriteLine("Sign up ok");
                            //responseJson = "{\"error\":\"false\",\"message\":\"User_Created\"}";
                            funcReply = ServerReplyStatus.Success;
                            break;
                        case CognitoResult.PasswordRequirementsFailed:
                            Debug.WriteLine("Password requirment failed");
                            //responseJson = "{\"error\":\"true\",\"message\":\"Pass_Req_Failed\"}";
                            funcReply = ServerReplyStatus.Success;
                            break;
                        case CognitoResult.UserNameAlreadyUsed:

                            Debug.WriteLine("Email exists");
                            //responseJson = "{\"error\":\"true\",\"message\":\"Email_Exist\"}";
                            funcReply = ServerReplyStatus.Success;
                            break;
                        default:
                            Debug.WriteLine($"strange error: {responseCognito.Error}");
                            //responseJson = "{\"error\":\"true\",\"message\":\"" + responseCognito.Error + "\"}";
                            funcReply = ServerReplyStatus.Fail;
                            break;
                    }

                    break;





                case AuthType.SignIn:
                    user = _connectInfo.Email.Trim().ToLower();
                    pass = _connectInfo.Password.Trim();

                    responseCognito = await AuthApi.SignIn(user, pass);

                    Debug.WriteLine($" Reply from aws Auth: {responseCognito.Result} ");
                    switch (responseCognito.Result)
                    {
                        case CognitoResult.Ok:
                            //responseJson = "{\"error\":\"false\",\"message\":\"--\"}";
                            Debug.WriteLine($"From:{this.GetType().Name},Login success");
                            funcReply = ServerReplyStatus.Success;
                            //MyApp.Session.PopulateSession(responseCognito as SignInContext);
                            break;
                        case CognitoResult.NotConfirmed:
                            Debug.WriteLine($"From:{this.GetType().Name},Email not confirmed");
                            //responseJson = "{\"error\":\"true\",\"message\":\"Email_Not_Activated\"}";
                            funcReply = ServerReplyStatus.Fail;
                            break;
                        case CognitoResult.InvalidPassword:
                            Debug.WriteLine($"From:{this.GetType().Name},Invalid Password");
                            //responseJson = "{\"error\":\"true\",\"message\":\"Password_Mismatch\"}";
                            funcReply = ServerReplyStatus.Fail;
                            break;
                        case CognitoResult.UserNotFound:
                            Debug.WriteLine($"From:{this.GetType().Name},Email not found");
                            //responseJson = "{\"error\":\"true\",\"message\":\"Email_Not_Exist\"}";
                            funcReply = ServerReplyStatus.Fail;
                            break;
                        default:
                            Debug.WriteLine($"strange error: {responseCognito.Error}");
                            //responseJson = "{\"error\":\"true\",\"message\":\"" + responseCognito.Error + "\"}";
                            funcReply = ServerReplyStatus.Fail;
                            break;
                    }
                    break;
            }

           

            return funcReply;
        }
    }
}

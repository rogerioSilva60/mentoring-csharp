﻿using RestWithASPNET.Data.VO;

namespace RestWithASPNET.Business
{
    public interface ILoginBusiness
    {
        TokenVO ValidateCredentials(UserVO user);

        TokenVO ValidateCredentials(TokenRefreshVO token);

        bool RevokeToken(string userName);
    }
}
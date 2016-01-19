﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Razzil.Domain
{
    public enum StatusCode
    {
        IN_PROCESS = 100,
        SUCCESS = 200,
        UNKNOWN = 0,
        NETWORK_ERROR_BEFORE_OTP = 400,
        INVALID_USERNAME_PASSWORD = 401,
        ACCOUNT_BLOCKED = 402,
        TRANSFER_TARGET_ACCOUNT_ERROR = 403,
        NOT_ENOUGH_BALANCE_ERROR = 404,
        LOGIN_CAPTCHA_ERROR = 405,
        UNKNOWN_ERROR_BEFORE_OTP = 406,
        UNKNOWN_ERROR_AFTER_OTP = 407,
        OTP_INCORRECT = 408,
        OTP_TIMEOUT_ERROR = 409,
        OTP_CAPTCHA_ERROR = 410,
        TRANSFER_SOURCE_ACCOUNT_ERROR = 411,
        PARSE_RESULT_PAGE_ERROR = 412,
        LOGIN_CAPTCHA_TIMEOUT = 413,
        OTP_CAPTCHA_TIMEOUT = 414,
        AMOUNT_ERROR = 415,
        CAN_NOT_CONTINUE_MAKE_TRANSFER = 416,
        BANK_PAGE_CHANGED = 418,
        DOWNLOAD_OTP_CAPTCHA_ERROR = 419,
        DOWNLOAD_LOGIN_CAPTCHA_ERROR = 420,
        NETWORK_ERROR_AFTER_SUCCEED = 422,
        NETWORK_ERROR_AFTER_OTP = 423,
        INCORRECT_ACCOUNT_NAME = 424,
        SESSION_TIMEOUT_BEFORE_SUCCEED = 425,
        SESSION_TIMEOUT_AFTER_OTP = 426,
        SESSION_TIMEOUT_AFTER_SUCCEED = 427,
        UNABLE_ENQUIRE_BALANCE_AFTER_SUCCEED = 428,
    }
}

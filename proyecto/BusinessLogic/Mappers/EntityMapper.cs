using DataAccess.Entities;
using LayeredApp.Business.DTOs;

namespace LayeredApp.Business.Mappers
{
    public static class EntityMapper
    {
        public static UserDto ToDto(this User u)
        {
            if (u == null) return null!;
            return new UserDto
            {
                Id = u.Id,
                Username = u.Username,
                Email = u.Email,
                IsFirstLogin = u.IsFirstLogin,
                Role = u.Role,
                CreatedAt = u.CreatedAt
            };
        }

        public static SystemConfigDto ToDto(this SystemConfig c)
        {
            if (c == null) return null!;
            return new SystemConfigDto
            {
                MinPasswordLength = c.MinPasswordLength,
                QuestionsToAnswer = c.QuestionsToAnswer,
                RequireUpperLower = c.RequireUpperLower,
                RequireDigits = c.RequireDigits,
                RequireSpecial = c.RequireSpecial,
                Require2FA = c.Require2FA,
                DisallowPreviousPasswords = c.DisallowPreviousPasswords,
                DisallowPersonalData = c.DisallowPersonalData
            };
        }

        public static SecurityQuestionDto ToDto(this SecurityQuestion q)
        {
            if (q == null) return null!;
            return new SecurityQuestionDto
            {
                Id = q.Id,
                UserId = q.UserId,
                Question = q.Question
            };
        }
    }
}


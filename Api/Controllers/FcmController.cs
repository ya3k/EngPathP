using Api.Dto;
using Application.ServiceContracts;
using Domain.Entity;
using Domain.Identity;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FcmController : ControllerBase
    {
        private readonly IFcmService _fcmService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUser _currentUser;
        public FcmController(IFcmService fcmService, IUnitOfWork unitOfWork, ICurrentUser currentUser)
        {
            _fcmService = fcmService;
            _unitOfWork = unitOfWork;
            _currentUser = currentUser;
        }

        
      

        //save device token
        [HttpPost("device-token")]
        public async Task<IActionResult> SaveDeviceToken([FromBody] SaveTokenRequest saveTokenRequest)
        {
            if (string.IsNullOrEmpty(saveTokenRequest.DeviceToken))
            {
                return BadRequest("Device token cannot be null or empty.");
            }
            try
            {
                var existingToken = await _unitOfWork.Repository<FcmDeviceTokens>().FindAsync(t => t.DeviceToken == saveTokenRequest.DeviceToken);
                if (existingToken.Any())
                {
                    return BadRequest("Device token already exists.");
                }
                var userId = await _currentUser.GetCurrentUserIdAsync();

                var newToken = new FcmDeviceTokens
                {
                    UserId = userId,
                    DeviceToken = saveTokenRequest.DeviceToken,
                    DeviceType = saveTokenRequest.DeviceType, 
                    IsActive = true,
                };

                await _unitOfWork.Repository<FcmDeviceTokens>().AddAsync(newToken);
                await _unitOfWork.SaveChangesAsync();
                return Ok("Device token saved successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error saving device token: {ex.Message}");
            }
        }

        //send notification
        [HttpPost("send-notification")]
        public async Task<IActionResult> SendNotification([FromBody] SendNotificationRequest request)
        {
            var notificationRepo = _unitOfWork.Repository<FcmNotification>();
            if (string.IsNullOrEmpty(request.Title) || string.IsNullOrEmpty(request.Body))
            {
                return BadRequest("Title and body cannot be null or empty.");
            }
            try
            {
                await _fcmService.SendNotificationAsync(request.Title, request.Body);

                var notification = new FcmNotification
                {
                    Title = request.Title,
                    Body = request.Body,
                };

                await notificationRepo.AddAsync(notification);
                await _unitOfWork.SaveChangesAsync();
                return Ok("Notification sent successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error sending notification: {ex.Message}");
            }
        }

    }
}

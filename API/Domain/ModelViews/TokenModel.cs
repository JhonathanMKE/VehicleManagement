namespace vehicle_management.Domain.ModelViews;


    public record TokenModel
    {
        public string Email { get; set; } = default!;
        public string Profile { get; set; } = default!;
        public string Token { get; set; } = default!;
    }

﻿using System.Security.Claims;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorBattles.Client;

public class CustomAuthStateProvider : AuthenticationStateProvider
{
    private readonly HttpClient _httpClient;
    private readonly ILocalStorageService _localStorageService;

    public CustomAuthStateProvider(ILocalStorageService localStorageService, HttpClient httpClient)
    {
        _httpClient = httpClient;
        _localStorageService = localStorageService;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var state = new AuthenticationState(new ClaimsPrincipal());
        
        
        if (await _localStorageService.GetItemAsync<bool>("isAuthenticated"))
        {
            var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, "John"),
                },
                "test authentication type");

            var user = new ClaimsPrincipal(identity);

            state = new AuthenticationState(user);
            
        }
        NotifyAuthenticationStateChanged(Task.FromResult(state));
        return state;
    }
}
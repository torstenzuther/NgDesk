﻿using FluentAssertions;
using NgDesk.Contracts;
using Xunit;

namespace NgDesk.Test;

public class FilePathTests
{
    [Theory]
    [InlineData("/test")]
    [InlineData("\test")]
    [InlineData(".")]
    [InlineData("..")]
    [InlineData("test\\")]
    public void FilePath_Should_Be_Implicitly_Converted_To_String(string given)
    {
        FilePath givenAsFilePath = given;
            
        given.Should().BeEquivalentTo(givenAsFilePath);
    }
        
    [Theory]
    [InlineData("/test")]
    [InlineData("\test")]
    [InlineData(".")]
    [InlineData("..")]
    [InlineData("test\\")]
    public void FilePath_Should_Be_Implicitly_Converted_From_String(string given)
    {
        FilePath filePath = given;
        FilePath givenAsFilePath = given;
            
        filePath.Should().BeEquivalentTo(givenAsFilePath);
    }
        
    [Theory]
    [InlineData("/test", "test")]
    [InlineData("\test", "\test")]
    [InlineData(".", ".")]
    [InlineData("..", "..")]
    [InlineData("test\\", "test\\")]
    public void FilePath_Should_Be_Implicitly_Converted_From_UriPath(string given, string expected)
    {
        UriPath givenUriPath = given;
        FilePath givenAsFilePath = givenUriPath;
        FilePath expectedAsFilePath = expected;
            
        givenAsFilePath.Should().BeEquivalentTo(expectedAsFilePath);
    }
}
CREATE FUNCTION dbo.CountWordsInSentence (@Sentence VARCHAR(MAX))
RETURNS INT
AS
BEGIN
    DECLARE @WordCount INT;
    DECLARE @CleanedSentence VARCHAR(MAX);
    SET @CleanedSentence = LTRIM(RTRIM(@Sentence));

    WHILE CHARINDEX('  ', @CleanedSentence) > 0
    BEGIN
        SET @CleanedSentence = REPLACE(@CleanedSentence, '  ', ' ');
    END
    IF @CleanedSentence IS NULL OR @CleanedSentence = ''
        SET @WordCount = 0;
    ELSE
        SET @WordCount = LEN(@CleanedSentence) - LEN(REPLACE(@CleanedSentence, ' ', '')) + 1;

    RETURN @WordCount;
END;
GO 

SELECT dbo.CountWordsInSentence('hello xyz');
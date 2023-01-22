import * as HelperFunctions from "./HelperFunctions";
// @ponicode
describe("HelperFunctions.ValidateEmail", () => {
  test("0", () => {
    let result: any = HelperFunctions.ValidateEmail("TestUpperCase@Example.com");
    expect(result).toMatchSnapshot();
  });

  test("1", () => {
    let result: any = HelperFunctions.ValidateEmail("email@Google.com");
    expect(result).toMatchSnapshot();
  });

  test("2", () => {
    let result: any = HelperFunctions.ValidateEmail("user@host:300");
    expect(result).toMatchSnapshot();
  });

  test("3", () => {
    let result: any = HelperFunctions.ValidateEmail("ponicode.com");
    expect(result).toMatchSnapshot();
  });

  test("4", () => {
    let result: any = HelperFunctions.ValidateEmail("user1+user2@mycompany.com");
    expect(result).toMatchSnapshot();
  });

  test("5", () => {
    let result: any = HelperFunctions.ValidateEmail("");
    expect(result).toMatchSnapshot();
  });
});

// @ponicode
describe("HelperFunctions.ValidatePassword", () => {
  test("0", () => {
    let result: any = HelperFunctions.ValidatePassword("YouarenotAllowed2Use");
    expect(result).toMatchSnapshot();
  });

  test("1", () => {
    let result: any = HelperFunctions.ValidatePassword("!Lov3MyPianoPony");
    expect(result).toMatchSnapshot();
  });

  test("2", () => {
    let result: any = HelperFunctions.ValidatePassword("accessdenied4u");
    expect(result).toMatchSnapshot();
  });

  test("3", () => {
    let result: any = HelperFunctions.ValidatePassword("NoWiFi4you");
    expect(result).toMatchSnapshot();
  });

  test("4", () => {
    let result: any = HelperFunctions.ValidatePassword("");
    expect(result).toMatchSnapshot();
  });
});

// @ponicode
describe("HelperFunctions.ValidateNumeric", () => {
  test("0", () => {
    let result: any = HelperFunctions.ValidateNumeric("+33 6 49 64 08 08'");
    expect(result).toMatchSnapshot();
  });

  test("1", () => {
    let result: any = HelperFunctions.ValidateNumeric("0322 999 999'");
    expect(result).toMatchSnapshot();
  });

  test("2", () => {
    let result: any = HelperFunctions.ValidateNumeric("0649640808'");
    expect(result).toMatchSnapshot();
  });

  test("3", () => {
    let result: any = HelperFunctions.ValidateNumeric("+1-541-754-3010'");
    expect(result).toMatchSnapshot();
  });

  test("4", () => {
    let result: any = HelperFunctions.ValidateNumeric("+44 7911 123456'");
    expect(result).toMatchSnapshot();
  });

  test("5", () => {
    let result: any = HelperFunctions.ValidateNumeric("");
    expect(result).toMatchSnapshot();
  });
});

// @ponicode
describe("HelperFunctions.ValidateLetters", () => {
  test("0", () => {
    let result: any = HelperFunctions.ValidateLetters("2017-09-29T23:01:00.000Z");
    expect(result).toMatchSnapshot();
  });

  test("1", () => {
    let result: any = HelperFunctions.ValidateLetters("01:04:03");
    expect(result).toMatchSnapshot();
  });

  test("2", () => {
    let result: any = HelperFunctions.ValidateLetters("Mon Aug 03 12:45:00");
    expect(result).toMatchSnapshot();
  });

  test("3", () => {
    let result: any = HelperFunctions.ValidateLetters("");
    expect(result).toMatchSnapshot();
  });
});

// @ponicode
describe("HelperFunctions.ValidateDates", () => {
  test("0", () => {
    let result: any = HelperFunctions.ValidateDates(
      "2017-09-29T19:01:00.000",
      "2017-09-29T19:01:00.000"
    );
    expect(result).toMatchSnapshot();
  });

  test("1", () => {
    let result: any = HelperFunctions.ValidateDates(
      "2017-09-29T23:01:00.000Z",
      "Mon Aug 03 12:45:00"
    );
    expect(result).toMatchSnapshot();
  });

  test("2", () => {
    let result: any = HelperFunctions.ValidateDates("01:04:03", "Mon Aug 03 12:45:00");
    expect(result).toMatchSnapshot();
  });

  test("3", () => {
    let result: any = HelperFunctions.ValidateDates("01:04:03", "2017-09-29T23:01:00.000Z");
    expect(result).toMatchSnapshot();
  });

  test("4", () => {
    let result: any = HelperFunctions.ValidateDates(
      "Mon Aug 03 12:45:00",
      "2017-09-29T23:01:00.000Z"
    );
    expect(result).toMatchSnapshot();
  });

  test("5", () => {
    let result: any = HelperFunctions.ValidateDates("", "");
    expect(result).toMatchSnapshot();
  });
});

// @ponicode
describe("HelperFunctions.ValidateNumericLoan", () => {
  test("0", () => {
    let result: any = HelperFunctions.ValidateNumericLoan("+44 7911 123456'");
    expect(result).toMatchSnapshot();
  });

  test("1", () => {
    let result: any = HelperFunctions.ValidateNumericLoan("0649640808'");
    expect(result).toMatchSnapshot();
  });

  test("2", () => {
    let result: any = HelperFunctions.ValidateNumericLoan("+33 6 49 64 08 08'");
    expect(result).toMatchSnapshot();
  });

  test("3", () => {
    let result: any = HelperFunctions.ValidateNumericLoan("0322 999 999'");
    expect(result).toMatchSnapshot();
  });

  test("4", () => {
    let result: any = HelperFunctions.ValidateNumericLoan("");
    expect(result).toMatchSnapshot();
  });
});

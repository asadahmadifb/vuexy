
using AspnetCoreMvcStarter.Models;

namespace AspnetCoreMvcStarter.Content
{
    public static class Contents
    {
        public static string GettableStructure(string tablename)
        {
			string tableStructure = "";

            switch (tablename)
			{
				case "vw_Projects":
					tableStructure = @"CREATE TABLE [Projects](
						[ProjectID] [int] NOT NULL,
						[RequestDate] [nvarchar](10) NULL,
						[Symbol] [nvarchar](8) NOT NULL,
						[PlatformName] [nvarchar](256) NOT NULL,
						[Applicant] [nvarchar](200) NOT NULL,
						[NationalID] [bigint] NOT NULL,
						[ProjectTitle] [nvarchar](256) NOT NULL,
						[ApprovalDate] [nvarchar](10) NULL,
						[TotalFundingRequired] [bigint] NOT NULL,
						[TotalRaisedAmount] [bigint] NULL,
						[ActualRaisedAmount] [bigint] NULL,
						[LegalRaisedAmount] [bigint] NULL,
						[IndividualContributorsCount] [int] NULL,
						[LegalContributorsCount] [int] NULL,
						[FundCollectionDate] [nvarchar](10) NULL,
						[ProjectStartDate] [nvarchar](10) NULL,
						[ProjectEndDate] [nvarchar](10) NULL,
						[Status] [nvarchar](56) NOT NULL,
						[CollateralType] [nvarchar](55) NOT NULL,
						[InterestRate] [decimal](18, 2) NULL,
						[PaymentFrequency] [int] NULL,
						[FinancialInstitutionID] [bigint] NULL,
						[FinancialInstitutionName] [nvarchar](1024) NULL
					) ON [PRIMARY]";
					break;
				case "ProjectFinancingProvider":
					tableStructure = @"
						CREATE TABLE [dbo].[ProjectFinancingProvider](
							[ID] [int] IDENTITY(1,1) NOT NULL,
							[ProjectID] [int] NOT NULL,
							[NationalID] [bigint] NOT NULL,
							[PersonType] [int] NOT NULL,
							[ProvidedFinancePrice] [bigint] NOT NULL,
							[BourseCode] [nvarchar](20) NOT NULL,
							[PaymentDate] [datetime] NOT NULL,
							[CreationDate] [datetime] NOT NULL,
							[PersianPaymentDate] [nvarchar](max) NULL,
							[PersianCreationDate] [nvarchar](max) NULL,
							[TraceCode] [uniqueidentifier] NOT NULL,
							[FirstName] [nvarchar](256) NULL,
							[LastNameOrCompanyName] [nvarchar](256) NOT NULL,
							[IsAccepted] [bit] NULL,
							[AcceptOrRejectDate] [datetime] NULL,
							[AcceptOrRejectUserID] [bigint] NULL,
							[IsDeleted] [bit] NULL,
							[BankTrackingNumber] [nvarchar](max) NULL,
							[VerifiedBourseCode] [nvarchar](max) NULL,
							[BourseCodeVerificationDate] [datetime] NULL,
							[PersianBourseCodeVerificationDate] [nvarchar](max) NULL,
							[MobileNumber] [nvarchar](max) NULL,
							[ShebaBankAccountNumber] [nvarchar](max) NULL,
							[VerifiedFirstName] [nvarchar](max) NULL,
							[VerifiedLastName] [nvarchar](max) NULL,
							[VerifiedFatherName] [nvarchar](max) NULL,
							[VerifiedBirthDate] [nvarchar](max) NULL,
						 CONSTRAINT [PK_dbo.ProjectFinancingProvider] PRIMARY KEY CLUSTERED 
						(
							[ID] ASC
						)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
						) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
					";
					break;
				default:
					break;
			}

            return tableStructure;
        }

        public static string GetContent(FileModel fileModel)
		{
			string content = "";

			return content;
		}

    }
}

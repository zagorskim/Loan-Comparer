export interface UserDetails {
  email: string;
  firstName: string;
  lastName: string;
  jobType: JobTypes;
  jobStartDate: Date;
  jobEndDate: Date;
  creationDate: Date;
  levelIncome: number;
  accountType: string;
  governmentIdType: GovernmentDocumentTypes;
  governmentId: string;
  token: string;
  birthDate: Date;
}

export interface InquiryData {
  bankId: number;
  creationDate: Date;
  inquiryId: string;
  installmentsAmount: number;
  moneyAmount: number;
  offerFromBank: OfferData;
  id: string;
  documentId: string;
  documentType: GovernmentDocumentTypes;
  firstName: string;
  lastName: string;
  jobType: JobTypes;
  incomeLevel: number;
}
export interface OfferData {
  creationDate: Date;
  id: string;
  installmentAmount: number;
  moneyAmount: number;
  monthlyInstallment: number;
  percentage: number;
  offerStatus: string;
}

export interface RequestData {
  creationDate: Date;
  documentId: string;
  documentType: number;
  firstName: string;
  id: string;
  incomeLevel: number;
  installmentsCount: number;
  jobType: JobTypes;
  lastName: string;
  moneyAmount: number;
}

export interface InquiryDetails {
  value: number;
  installmentsNumber: number;
  personalData: PersonalData;
  governmentDocument: GovernmentDocument;
  jobDetails: JobDetails;
}

export interface PersonalData {
  firstName: string;
  lastName: string;
  birthDate: Date;
}

export interface GovernmentDocument {
  typeId: GovernmentDocumentTypes;
  name: string;
  description: string;
  number: string;
}

export interface JobDetails {
  typeId: JobTypes;
  name: string;
  description: string;
  jobStartDate: Date;
  jobEndDate: Date;
}

export interface OfferDetails {
  bankId: BankNames;
  creationDate: Date;
  externalOfferId: string;
  id: string;
  inquiryId: string;
  installmentAmount: number;
  moneyAmount: number;
  monthlyInstallment: number;
  percentage: number;
  userId: string;
}

export enum JobTypes {
  Director = 30 as any,
  Agent = 37 as any,
  Administrator = 44 as any,
  Coordinator = 47 as any,
  Specialist = 60 as any,
  Orchestrator = 62 as any,
  Assistant = 64 as any,
  Designer = 69 as any,
  Facilitator = 72 as any,
  Analyst = 79 as any,
  Producer = 80 as any,
  Technician = 81 as any,
  Manager = 84 as any,
  Liaison = 87 as any,
  Associate = 88 as any,
  Consultant = 89 as any,
  Engineer = 92 as any,
  Strategist = 93 as any,
  Supervisor = 94 as any,
  Executive = 95 as any,
  Planner = 96 as any,
  Developer = 97 as any,
  Officer = 98 as any,
  Architect = 99 as any,
  Representative = 100 as any,
}

export enum GovernmentDocumentTypes {
  DriverLicense = 1 as any,
  Passport = 2 as any,
  GovernmentId = 3 as any,
}

export enum BankNames {
  LocalBank,
  TeachersBank,
  OtherBank,
}

// TEMPLATE FOR INQ DETAILS COMPONENT
{
  /* <Inquiry personalData={{firstName: x.personalData.firstName, lastName: x.personalData.lastName, birthDate: x.personalData.birthDate}} 
                governmentDocument={{typeId: x.governmentDocument.typeId, name: x.governmentDocument.name, description: x.governmentDocument.description, number: x.governmentDocument.number}}
                jobDetails={{typeId: x.jobDetails.typeId, name: x.jobDetails.name, description: x.jobDetails.description, jobStartDate: x.jobDetails.jobStartDate, jobEndDate: x.jobDetails.jobEndDate}}
                value={x.value} 
                installmentsNumber={x.installmentsNumber}></Inquiry> */
}

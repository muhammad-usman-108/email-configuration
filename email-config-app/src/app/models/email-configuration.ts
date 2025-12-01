export interface EmailConfiguration {
  id?: number;
  name: string;
  watchedFolder: string;
  provider: 'Exchange' | 'IMAP';
  storeAttachments: boolean;
}

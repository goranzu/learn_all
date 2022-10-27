import { Photo } from './IPhoto';

export interface IMember {
  id: number;
  username: string;
  photoUrl: string;
  age: number;
  knownAs?: any;
  createdAt: Date;
  lastActive: Date;
  gender: string;
  introduction: string;
  lookingFor: string;
  interests: string;
  city: string;
  country: string;
  photos: Photo[];
}

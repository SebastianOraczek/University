export interface Character {
  id: number;
  name: string;
  status: string;
  species: string;
  type: string;
  gender: string;
  origin: Origin;
  location: Location;
  image: string;
  episode: Array<string>;
  url: string;
  created: string;
}

export enum CharacterStatus {
  Alive = 'alive',
  Dead = 'dead',
  Unknown = 'unknown',
}

export enum CharacterGender {
  Female = 'female',
  Male = 'male',
  Genderless = 'genderless',
  Unknown = 'unknown',
}

export interface DefaultCharacterFilters {
  status: CharacterStatus | undefined;
  gender: CharacterGender | undefined;
  name: string;
  species: string;
  type: string;
}

interface Origin {
  name: string;
  url: string;
}

type Location = Origin;

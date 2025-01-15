export interface MovieSimple {
  id: number;
  title: string;
}
    
export interface MovieDetailed extends MovieSimple {
  durationMinutes: number;
  releaseYear: number;
  genreId: number;
}  
  
export interface MovieCreate {
  title: string;
  description: string;
  durationMinutes: number;
  releaseYear: number;
  // other properties...
}

export interface MovieUpdate {
  title?: string;
  description?: string;
  durationMinutes: number;
  releaseYear: number;
  // other properties...
}
  
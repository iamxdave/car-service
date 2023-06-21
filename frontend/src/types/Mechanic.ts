export default interface Mechanic {
  idPerson: string;
  name: string;
  surname: string;
  bookedDates: BookedDate[];
}

type BookedDate = {
  start: Date, 
  end: Date
}
import axios from 'axios'
export const fetchNotes = async (filter) =>{
    try
    {
        var response = await axios.get('http://sayplswis.ru:5000/notes',{
            params:{
                search: filter?.search,
                sortItem: filter?.sortItem,
                sortOrder: filter?.sortOrder
            }
        });
        return response.data;
    } 
    catch(e)
    {
        console.error(e);
    }
}

export const createNote = async (note) =>{
    try
    {
        var response = await axios.post('http://sayplswis.ru:5000/notes',note);
        return response.status;
    } 
    catch(e)
    {
        console.error(e);
    }
}

export const deleteNote = async (id) =>{
    try
    {
        console.log('Sending data:', { id });
        console.log(typeof id)
        var response = await axios.post('http://sayplswis.ru:5000/notes/delete', {id});
        return response.status;
    } 
    catch(e)
    {
        console.error(e);
        console.error('Error response:', e.response);
    }
}
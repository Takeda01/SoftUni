import { Theme } from "./theme"
import { userId } from "./userID"

export interface Post{
    
        likes: string[]
        _id: string
        text:string
        userId: userId
        themeId: Theme
        created_at: string
        updatedAt: string
        __v: number
    }
    




package day6;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.Scanner;

public class Part1 {
    public static void main(String[] args) {

        ArrayList<ArrayList<Character>> input1 = new ArrayList<>();

    try {
        File myObj = new File("day6\\input.txt");
        Scanner myReader = new Scanner(myObj);
        while (myReader.hasNextLine()) {
            String data = myReader.nextLine();
            ArrayList<Character> arr = new ArrayList<>();
            for(char a:data.toCharArray()){
                arr.add(a);
            }
            input1.add(arr);
        }
        myReader.close();
        } catch (FileNotFoundException e) {
        }
        char[][] input = new char[input1.size()][input1.get(0).size()];
        for(int i = 0; i<input.length;i++){
            for(int j = 0; j<input[i].length;j++){
                input[i][j] = input1.get(i).get(j);
            }
        }

        int[][] directions = {{-1,0},{0,1},{1,0},{0,-1}};
        int cd = 0;
        int[] current_position = {0,0};

        for(int i = 0; i<input.length;i++){
            for(int j = 0; j<input[i].length;j++){
                if(input[i][j]=='^'){
                    current_position[0] = i;
                    current_position[1] = j;
                }
            }
        }


        while(isOut(current_position[0], current_position[1], input)){
            input[current_position[0]][current_position[1]] = 'X';
            try {
                if(input[current_position[0]+directions[cd][0]][current_position[1]+directions[cd][1]]=='#'){
                    if(cd==3){
                        cd = 0;
                    }else cd++;
                }
            } catch (Exception e) {
            }
            current_position[0] = current_position[0]+directions[cd][0];
            current_position[1] = current_position[1]+directions[cd][1];
        }
        
        int wynik = 0;
        for(int i = 0; i<input.length;i++){
            for(int j = 0; j<input[i].length;j++){
                if(input[i][j]=='X')wynik++;
            }
        }
        System.out.println(wynik);
    }


    public static boolean isOut(int x, int y,char[][] input){
        try {
            if(input[x][y]=='m'){}
            return true;
        } catch (Exception e) {
            return false;
        }
        
    }
}
